using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Keyboard;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Dto;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using LiveView.Services.VideoServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Joystick;
using Mtf.LanguageService;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Enums;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using Mtf.Serial.Enums;
using Mtf.Serial.SerialDevices;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;
using NetworkServer = Mtf.Network.Server;

namespace LiveView.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private const string UserShouldHaveAtLeastPriority = "User '{0}' should have at least '{1}' secondary logon priority.";
        private SltWatchdog watchdog;

        private readonly ILogger<MainForm> logger;
        private readonly Uptime uptime;
        private readonly ICameraRepository cameraRepository;
        private readonly IServiceProvider serviceProvider;
        private readonly IMapRepository mapRepository;
        private readonly IMapObjectRepository mapObjectRepository;
        private readonly IDisplayRepository displayRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IRightRepository rightRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserEventRepository userEventRepository;
        private readonly ITemplateRepository templateRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IAgentRepository agentRepository;
        private readonly IOperationRepository operationRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly IUsersInGroupsRepository userGroupRepository;

        private IMainView view;
        private MapLoader mapLoader;
        //private KBD300A kBD300A = new KBD300A("COM1");

        public MainPresenter(MainPresenterDependencies dependencies)
            : base(dependencies)
        {
            logger = dependencies.Logger;
            cameraRepository = dependencies.CameraRepository;
            rightRepository = dependencies.RightRepository;
            serviceProvider = dependencies.ServiceProvider;
            mapRepository = dependencies.MapRepository;
            mapObjectRepository = dependencies.MapObjectRepository;
            displayRepository = dependencies.DisplayRepository;
            groupRepository = dependencies.GroupRepository;
            userRepository = dependencies.UserRepository;
            templateRepository = dependencies.TemplateRepository;
            userGroupRepository = dependencies.UserGroupRepository;
            personalOptionsRepository = dependencies.PersonalOptionsRepository;
            permissionManager = dependencies.PermissionManager;
            agentRepository = dependencies.AgentRepository;
            operationRepository = dependencies.OperationRepository;
            userEventRepository = dependencies.UserEventRepository;
            agentRepository.DeleteAll();
            uptime = new Uptime();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IMainView;
        }

        public override void Load()
        {
            logger.LogInfo(ApplicationManagementPermissions.Start, "Application started.");
            //MousePointer.ShowOnCtrlKey();
            RegisterHotkey();
            StartServer();
            LoadFirstMap();
            LoadEvents();
            CheckLanguageFile();
            StartJoystick();
            StartMotionTriggeredCameras();
        }

        private void LoadEvents()
        {
            var userEvents = userEventRepository.SelectAll();
            view.LvUserEvents.AddItems(userEvents, (userEvent) =>
            {
                var result = new ListViewItem(userEvent.Name) { Tag = userEvent, ToolTipText = userEvent.Note };
                result.SubItems.Add(userEvent.Note);
                return result;
            });
        }

        private void StartServer()
        {
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var port))
            {
                try
                {
                    Globals.Server = new NetworkServer(listenerPort: port);
                    Globals.Server.DataArrived += DataArrivedEventHandler;
                    Globals.Server.Start();
                }
                catch (SocketException)
                {
                    Application.Restart();
                }

                view.TsslServerData.Text = $"{Globals.Server.Socket.LocalEndPoint} ({Lng.Elem("Listening on")}: {String.Join(", ", NetUtils.GetLocalIPAddresses(AddressFamily.InterNetwork))})";
            }
        }

        private void RegisterHotkey()
        {
            var handle = view.GetHandle();
            WinAPI.RegisterHotKey(handle, 1, ModifierKeys.NO_MODIFIER, VirtualKeyCodes.VK_HOME);
        }

        private void ShowControlCenter()
        {
            if (generalOptionsRepository.Get(Setting.OpenControlCenterWhenProgramStarts, true))
            {
                if (Globals.ControlCenter != null)
                {
                    Globals.ControlCenter.Close();
                }
                Globals.ControlCenter = ShowForm<ControlCenter>();
            }
        }

        public void AutoLoadTemplate()
        {
            var templates = templateRepository.SelectAll();
            var templateToLoad = generalOptionsRepository.Get(Setting.AutoLoadedTemplate, String.Empty);
            var autoLoadTemplate = templates.FirstOrDefault(template => template.TemplateName == templateToLoad);
            if (autoLoadTemplate != null)
            {
                if (Globals.ControlCenter == null)
                {
                    Globals.ControlCenter = ShowForm<ControlCenter>();
                    Globals.ControlCenter.StartTemplate(autoLoadTemplate);
                    Globals.ControlCenter.Close();
                }
                else
                {
                    Globals.ControlCenter.StartTemplate(autoLoadTemplate);
                }
            }
        }

        private void StartJoystick()
        {
            var joystickInitialized = JoystickHandler.InitializeJoystick(
                    continuePulling: () => true,
                    getDeltaModifier: () => 10,
                    getMinimumDelta: () => 5,
                    restAction: (deltaX, deltaY) =>
                    {
                        SendMessageToFullScreenCamera(NetworkCommand.StopPanAndTilt.ToString());
                        SendMessageToFullScreenCamera(NetworkCommand.StopZoom.ToString());
                    },
                    forwardOrBackwardAction: (deltaX, deltaY) =>
                    {
                        if (deltaY < 0)
                        {
                            SendMessageToFullScreenCamera($"{NetworkCommand.TiltToNorth} {deltaY}");
                        }
                        else if (deltaY > 0)
                        {
                            SendMessageToFullScreenCamera($"{NetworkCommand.TiltToSouth} {deltaY}");
                        }
                    },
                    forwardWithLeftTurnAction: (deltaX, deltaY) =>
                    {
                        SendMessageToFullScreenCamera($"{NetworkCommand.PanToWestAndTiltToNorth} {deltaX} {deltaY}");
                    },
                    forwardWithRightTurnAction: (deltaX, deltaY) =>
                    {
                        SendMessageToFullScreenCamera($"{NetworkCommand.PanToEastAndTiltToNorth} {deltaX} {deltaY}");
                    },
                    backwardWithLeftTurnAction: (deltaX, deltaY) =>
                    {
                        SendMessageToFullScreenCamera($"{NetworkCommand.PanToWestAndTiltToSouth} {deltaX} {deltaY}");
                    },
                    backwardWithRightTurnAction: (deltaX, deltaY) =>
                    {
                        SendMessageToFullScreenCamera($"{NetworkCommand.PanToEastAndTiltToSouth} {deltaX} {deltaY}");
                    },
                    turnLeftOrRightAction: (deltaX, deltaY) =>
                    {
                        if (deltaX < 0)
                        {
                            SendMessageToFullScreenCamera($"{NetworkCommand.PanToWest} {deltaX}");
                        }
                        else if (deltaX > 0)
                        {
                            SendMessageToFullScreenCamera($"{NetworkCommand.PanToEast} {deltaX}");
                        }
                    },
                    afterPullingAction: () =>
                    {
                        SendMessageToFullScreenCamera(NetworkCommand.StopPanAndTilt.ToString());
                        SendMessageToFullScreenCamera(NetworkCommand.StopZoom.ToString());
                    },
                    buttonActions: new Action[]
                    {
                        () => Console.WriteLine("Button 1 pressed."),
                        () => Console.WriteLine("Button 2 pressed."),
                        () => Console.WriteLine("Button 3 pressed."),
                    }
                );
            view.TsslJoystick.Text = joystickInitialized ? Lng.Elem("Joystick initialized.") : Lng.Elem("Joystick not found.");
        }

        private void StartMotionTriggeredCameras()
        {
            var cameras = cameraRepository.SelectMotionTriggreredCameras();
            var motionCameras = cameras.Where(c => c.MotionTrigger != null);
            var connectionTimeout = generalOptionsRepository.Get(Setting.MaximumTimeToWaitForAVideoServerIs, 500);
            foreach (var motionCamera in motionCameras)
            {
                var partnerCamera = motionCamera.PartnerCameraId.HasValue ? cameras.FirstOrDefault(c => c.Id == motionCamera.PartnerCameraId) : null;
                var motionPopup = CreateForm<MotionPopup>(motionCamera, partnerCamera);
                _ = VideoCameraMotionTrigger.ConnectAsync(motionPopup, motionCamera, () =>
                {
                    if (!motionPopup.Visible)
                    {
                        motionPopup.ShowDialog();
                    }
                }, connectionTimeout);
            }
        }

        public void LoadLanguage(long userId)
        {
            var implementedLanguage = (ImplementedLanguage)personalOptionsRepository.Get(Setting.Language, userId, Constants.HungarianLanguageIndex);
            Lng.DefaultLanguage = Enum.TryParse(implementedLanguage.ToString(), out Mtf.LanguageService.Enums.Language selectedLanguage) ? selectedLanguage : Mtf.LanguageService.Enums.Language.Hungarian;
            LiveViewTranslator.Translate();
            Translator.Translate(view.GetSelf());
            ShowControlCenter();
            StartWatchdog();
        }

        private void StartWatchdog()
        {
            if (generalOptionsRepository.Get(Setting.UseWatchDog, false))
            {
                try
                {
                    string portName;
                    try
                    {
                        portName = SltWatchdog.GetPortName(WatcdogType.USB);
                    }
                    catch (InvalidOperationException)
                    {
                        portName = SltWatchdog.GetPortName(WatcdogType.COM);
                    }

                    watchdog = new SltWatchdog(portName);
                    watchdog.StartPetting();
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        public static void SendMessageToSequenceOnDisplay(DisplayDto display, string message)
        {
            foreach (var sequenceProcess in Globals.SequenceProcesses)
            {
                if (sequenceProcess.Value.DisplayId == display.GetId())
                {
                    Globals.Server.SendMessageToClient(sequenceProcess.Value.Socket, message, true);
                }
            }
        }

        public static void SendMessageToFullScreenCamera(string message)
        {
            var info = GetFullScreenInfo();
            if (info.Key != null)
            {
                Globals.Server.SendMessageToClient(info.Key, message, true);
            }
        }

        private static KeyValuePair<Socket, CameraProcessInfo> GetFullScreenInfo()
        {
            foreach (KeyValuePair<Socket, CameraProcessInfo> cameraProcessInfo in Globals.CameraProcessInfo)
            {
                if (cameraProcessInfo.Value.DisplayId != null)
                {
                    return cameraProcessInfo;
                }
            }
            return new KeyValuePair<Socket, CameraProcessInfo>(null, null);
        }

        private void CheckLanguageFile()
        {
            var actualHash = generalOptionsRepository.Get(Setting.LanguageFileHash, LanguageFileChangedPresenter.OriginalLanguageFileHash);
            if (LanguageFileChangedPresenter.IsModified(actualHash))
            {
                ShowForm<LanguageFileChangedForm>();
            }
        }

        private void DataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{Globals.Server?.Encoding.GetString(e.Data)}";
                var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var message in allMessages)
                {
                    var messageParts = message.Split('|');

                    if (message.StartsWith($"{NetworkCommand.RegisterAgent}|"))
                    {
                        Globals.Agents.Add(messageParts[1]);
                        Globals.ControlCenter?.RefreshAgents();
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterAgent}|"))
                    {
                        Globals.Agents.Remove(messageParts[1]);

                        //agentRepository.DeleteWhere(new { ServerIp = messageParts[1].Split(':')[0] });
                        Globals.ControlCenter?.RefreshAgents();
                    }
                    else if (message.StartsWith($"{NetworkCommand.RegisterDisplay}|"))
                    {
                        var display = JsonSerializer.Deserialize<DisplayDto>(messageParts[1]);
                        DisplayManager.RemoteDisplays.Add(display);
                        if (Globals.ControlCenter != null)
                        {
                            Globals.ControlCenter.CachedDisplays = null;
                        }
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterDisplay}|"))
                    {
                        var display = JsonSerializer.Deserialize<DisplayDto>(messageParts[1]);
                        DisplayManager.RemoteDisplays.Remove(display);
                        if (Globals.ControlCenter != null)
                        {
                            Globals.ControlCenter.CachedDisplays = null;
                        }
                    }
                    else if (message.StartsWith($"{NetworkCommand.SendCameraProcessId}|"))
                    {
                        var cameraProcessId = Convert.ToInt32(messageParts[1]);
                        Globals.CameraProcesses.Add(e.Socket.LocalEndPoint.ToString(), cameraProcessId);
                    }
                    else if (message.StartsWith($"{NetworkCommand.RegisterSequence}|"))
                    {
                        var localEndPoint = messageParts[1];
                        Globals.SequenceProcesses.TryAdd(localEndPoint, new SequenceProcessInfo
                        {
                            Socket = e.Socket,
                            UserId = Convert.ToInt64(messageParts[2]),
                            SequenceId = Convert.ToInt64(messageParts[3]),
                            DisplayId = Convert.ToInt64(messageParts[4]),
                            IsMdi = Convert.ToBoolean(messageParts[5]),
                            ProcessId = Convert.ToInt32(messageParts[6])
                        });
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterSequence}|"))
                    {
                        var localEndPoint = messageParts[1];
                        //var sequenceId = Convert.ToInt64(messageParts[2]);
                        //var processId = Convert.ToInt32(messageParts[3]);
                        Globals.SequenceProcesses.TryRemove(localEndPoint, out _);
                    }
                    else if (message.StartsWith($"{NetworkCommand.AgentDisconnected}|"))
                    {
                        agentRepository.DeleteWhere(new { ServerIp = messageParts[1] });
                    }
                    else if (message.StartsWith($"{NetworkCommand.VideoCaptureSourcesResponse}|"))
                    {
                        var videoCaptureSources = messageParts[1].Split(';')
                            .Select(vcs => vcs.Split('='))
                            .ToDictionary(vcs => vcs[0], vcs => vcs[1]);
                        Globals.VideoCaptureSources.Add(e.Socket, videoCaptureSources);
                        if (videoCaptureSources.Count > 0)
                        { 
                            agentRepository.DeleteWhere(new { ServerIp = videoCaptureSources.Values.First().Split(':')[0] });
                        }
                        foreach (var videoCaptureSource in videoCaptureSources)
                        {
                            var hostInfo = videoCaptureSource.Value.Split(':');
                            agentRepository.Insert(new Database.Models.Agent
                            {
                                VideoCaptureSourceName = videoCaptureSource.Key,
                                ServerIp = hostInfo[0],
                                Port = Convert.ToInt32(hostInfo[1])
                            });
                        }
                    }
                    else if (message.StartsWith($"{NetworkCommand.RegisterCamera}"))
                    {
                        Globals.CameraProcessInfo.Add(e.Socket, new CameraProcessInfo
                        {
                            LocalEndPoint = messageParts[1],
                            UserId = Convert.ToInt64(messageParts[2]),
                            CameraId = Convert.ToInt64(messageParts[3]),
                            DisplayId = !String.IsNullOrEmpty(messageParts[4]) ? (long?)Convert.ToInt64(messageParts[4]) : null,
                            ProcessId = Convert.ToInt32(messageParts[5])
                        });
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterCamera}|"))
                    {
                        Globals.CameraProcessInfo.Remove(e.Socket);
                    }
                    else if (message.StartsWith($"{NetworkCommand.SecondsLeftFromGrid}|"))
                    {
                        var gridId = Convert.ToInt64(messageParts[1]);
                        Globals.ControlCenter.ShowGridInfo(gridId, messageParts[2]);
                    }
                    else if (message.StartsWith($"{NetworkCommand.RegisterVideoSource}"))
                    {
                        Globals.CameraProcessInfo.Add(e.Socket, new CameraProcessInfo
                        {
                            LocalEndPoint = messageParts[1],
                            UserId = Convert.ToInt64(messageParts[2]),
                            ServerIp = messageParts[3],
                            VideoCaptureSource = messageParts[4],
                            DisplayId = !String.IsNullOrEmpty(messageParts[5]) ? (long?)Convert.ToInt64(messageParts[5]) : null,
                            ProcessId = Convert.ToInt32(messageParts[6])
                        });
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterVideoSource}|"))
                    {
                        Globals.CameraProcessInfo.Remove(e.Socket);
                    }
                    else if (message.StartsWith($"{NetworkCommand.Ping}"))
                    {
                        //AgentPingTimes.Add(messageParts[1], DateTime.UtcNow);
                    }
                    else
                    {
                        DebugErrorBox.Show("Unknown message arrived", message);
                    }
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        public Mtf.Permissions.Models.User<User> PrimaryLogon()
        {
            var user = userRepository.Login(view.TbUsername.Text, view.TbPassword.Password);
            if (user == null)
            {
                ShowError("Invalid username or password");
                return null;
            }

            var result = new Mtf.Permissions.Models.User<User>
            {
                Username = user.Username,
                Tag = user
            };
            SetGroups(result);

            if (user.NeededSecondaryLogonPriority > 0)
            {
                var secondaryLogonForm = ShowFormAsDialog<LoginForm>();
                if (secondaryLogonForm.DialogResult != DialogResult.OK)
                {
                    return null;
                }

                if (secondaryLogonForm.SecondaryUser.SecondaryLogonPriority < user.NeededSecondaryLogonPriority)
                {
                    var message = String.Format(UserShouldHaveAtLeastPriority, secondaryLogonForm.SecondaryUser, user.NeededSecondaryLogonPriority);
                    ShowError(message);
                    return null;
                }
            }

            ChangeControlsOnLogin(user.Username);
            return result;
        }

        private void SetGroups(Mtf.Permissions.Models.User<User> result)
        {
            result.Groups = new List<Mtf.Permissions.Models.Group>();
            var groupIds = userGroupRepository.SelectWhere(new { UserId = result.Tag.Id }).Select(userGroup => userGroup.GroupId);
            foreach (var groupId in groupIds)
            {
                SetUserGroup(result, groupId);
            }
        }

        private void SetUserGroup(Mtf.Permissions.Models.User<User> user, long groupId)
        {
            var group = new Mtf.Permissions.Models.Group();
            var groupPermissions = rightRepository.SelectWhere(new { GroupId = groupId, UserEventId = Globals.UserEvent?.Id ?? 1 });
            var operationIds = groupPermissions.Select(gp => gp.OperationId).ToList();
            var operations = operationRepository.SelectWhere(new { Ids = operationIds });
            var permissionType = typeof(CameraManagementPermissions);
            var assembly = permissionType.Assembly;

            foreach (var operation in operations)
            {
                var enumType = assembly.GetType($"{permissionType.Namespace}.{operation.PermissionGroup}");
                if (enumType != null && Enum.IsDefined(enumType, operation.PermissionValue))
                {
                    var enumValue = Enum.Parse(enumType, operation.PermissionValue);

                    group.Permissions.Add(new Mtf.Permissions.Models.Permission
                    {
                        PermissionGroup = enumType,
                        PermissionValue = Convert.ToInt64(enumValue)
                    });
                }
            }
            user.Groups.Add(group);
        }

        public static void MoveMouseToHome()
        {
            SendKeys.Send("{HOME}");
        }

        public bool Exit()
        {
            if (view.ShowConfirm(Lng.Elem("Confirmation"), Lng.Elem("Are you sure you want to exit?"), Decide.No))
            {
                JoystickHandler.StopJoystick();
                StopStartedApplications();
                var handle = view.GetHandle();
                WinAPI.UnregisterHotKey(handle, 1);
                Globals.Server.Stop();
                watchdog?.StopPetting();
                logger.LogInfo(ApplicationManagementPermissions.Exit, "Application stopped.");
                Environment.Exit(0);
                return true;
            }
            return false;
        }

        public void SetCursorPosition()
        {
            view.SetCursorPosition();
            SendKeys.Send("^");
        }

        public void SetUptime()
        {
            var osUptime = uptime.GetOs();
            var appUptime = uptime.GetApp();
            view.SetUptime(osUptime, appUptime);
        }

        public void LoadFirstMap()
        {
            var maps = mapRepository.SelectAll();
            if (maps.Count > 0)
            {
                var map = MapDto.FromModel(maps.First());
                map.MapObjects = mapObjectRepository.SelectWhere(new { map.Id }).Select(MapObjectDto.FromModel).ToArray();
                if (mapLoader == null)
                {
                    mapLoader = ActivatorUtilities.CreateInstance<MapLoader>(serviceProvider, view.PbMap, view.TtHint);
                    mapLoader.CameraObjectClicked += MapLoader_CameraObjectClicked;
                    mapLoader.VideoSourceObjectClicked += MapLoader_VideoSourceObjectClicked;
                }
                mapLoader.LoadMap(map);
            }
            else
            {
                view.PbMap.Image = Properties.Resources.IPVS37;
                view.PbMap.Controls.Clear();
            }
        }

        private void MapLoader_VideoSourceObjectClicked(CustomEventArgs.VideoSourceObjectClickedEventArgs e)
        {
            if (Globals.ControlCenter == null || Globals.ControlCenter.IsDisposed)
            {
                Globals.ControlCenter = ShowForm<ControlCenter>(null, e.VideoSource);
            }
            else
            {
                Globals.ControlCenter.StartVideoSource(e.VideoSource);
            }
        }

        private void MapLoader_CameraObjectClicked(CustomEventArgs.CameraObjectClickedEventArgs e)
        {
            if (Globals.ControlCenter == null || Globals.ControlCenter.IsDisposed)
            {
                Globals.ControlCenter = ShowForm<ControlCenter>(e.Camera);
            }
            else
            {
                Globals.ControlCenter.StartCamera(e.Camera);
            }
        }

        public static void StopStartedApplications()
        {
            ProcessUtils.Kill(ControlCenterPresenter.CameraProcess);
            foreach (var cameraProcessInfo in Globals.CameraProcessInfo)
            {
                Globals.Server.SendMessageToClient(cameraProcessInfo.Key, NetworkCommand.Close.ToString());
            }
            foreach (var cameraProcess in Globals.CameraProcesses)
            {
                SentToClient(cameraProcess.Key, NetworkCommand.Kill, Core.Constants.CameraExe, cameraProcess.Value);
            }
            foreach (var sequenceProcess in Globals.SequenceProcesses)
            {
                Globals.Server.SendMessageToClient(sequenceProcess.Value.Socket, NetworkCommand.Close.ToString());
            }
        }

        public static void SentToClient(string clientAddress, params object[] parameters)
        {
            try
            {
                using (var clientSocket = CreateSocket(clientAddress))
                {
                    Globals.Server.SendMessageToClient(clientSocket, String.Join("|", parameters), true);
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private static Socket CreateSocket(string clientAddress)
        {
            var parts = clientAddress.Split(':');
            string ipString = parts[0];
            int port = int.Parse(parts[1]);

            var ipAddress = IPAddress.Parse(ipString);
            var endPoint = new IPEndPoint(ipAddress, port);
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);
            return socket;
        }

        public void AutoLogin()
        {
            var users = userRepository.SelectAll();
            var autoLoginUserName = generalOptionsRepository.Get(Setting.AutoLoginUser, String.Empty);
            if (!String.IsNullOrEmpty(autoLoginUserName))
            {
                var user = users.FirstOrDefault(u => u.Username == autoLoginUserName);
                if (user != null)
                {
                    var permissionUser = new Mtf.Permissions.Models.User<User>
                    {
                        Username = user.Username,
                        Tag = user
                    };
                    SetGroups(permissionUser);
                    permissionManager.SetUser(view.GetSelf(), permissionUser);
                    LoadLanguage(permissionUser.Tag.Id);
                    ChangeControlsOnLogin(user.Username);
                }
            }
        }

        private void ChangeControlsOnLogin(string username)
        {
            view.TbUsername.ReadOnly = true;
            view.TbUsername.Text = username;
            view.LblPassword.Visible = false;
            view.TbPassword.Visible = false;
            view.GbPrimaryLogon.Size = new Size(253, 111);
            view.BtnLoginLogoutPrimary.Text = Lng.Elem("Logout");
            Globals.ControlCenter.SetImagesEnabledState();
        }

        private void ChangeControlsOnLogout()
        {
            view.TbUsername.ReadOnly = false;
            view.TbUsername.Text = String.Empty;
            view.LblPassword.Visible = true;
            view.TbPassword.Visible = true;
            view.TbPassword.Text = String.Empty;
            view.GbPrimaryLogon.Size = new Size(253, 161);
            view.BtnLoginLogoutPrimary.Text = Lng.Elem("Login");
            Globals.ControlCenter.SetImagesEnabledState();
        }

        public void Logout()
        {
            permissionManager.Logout(view.GetSelf());
            ChangeControlsOnLogout();
        }

        public void Login()
        {
            var user = PrimaryLogon();
            if (user != null)
            {
                permissionManager.SetUser(view.GetSelf(), user);
                LoadLanguage(user.Tag.Id);
            }
        }

        public void ChangeEvent(UserEvent userEvent)
        {
            var user = permissionManager.CurrentUser;
            logger.LogInfo(EventManagementPermissions.Update, $"User '{0}' changed the user event to '{1}'.", user, userEvent);
            Globals.UserEvent = userEvent;
            SetGroups(user);
            permissionManager.ApplyPermissionsOnControls(view.GetSelf());
        }
    }
}
