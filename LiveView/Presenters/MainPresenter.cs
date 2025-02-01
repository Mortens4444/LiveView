using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Keyboard;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Dto;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
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
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
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

        public readonly static Dictionary<Socket, Dictionary<string, string>> VideoCaptureSources = new Dictionary<Socket, Dictionary<string, string>>();
        public readonly static Dictionary<string, int> CameraProcesses = new Dictionary<string, int>();
        public readonly static ConcurrentDictionary<string, SequenceProcessInfo> SequenceProcesses = new ConcurrentDictionary<string, SequenceProcessInfo>();
        public readonly static Dictionary<Socket, CameraProcessInfo> CameraProcessInfo = new Dictionary<Socket, CameraProcessInfo>();
        
        public static BindingList<string> Agents { get; } = new BindingList<string>();
        //public readonly static Dictionary<string, DateTime> AgentPingTimes = new Dictionary<string, DateTime>();

        public static NetworkServer Server { get; private set; }
        private readonly ILogger<MainForm> logger;
        private readonly Uptime uptime;
        private readonly IServiceProvider serviceProvider;
        private readonly IMapRepository mapRepository;
        private readonly IMapObjectRepository mapObjectRepository;
        private readonly IDisplayRepository displayRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IRightRepository rightRepository;
        private readonly IUserRepository userRepository;
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
            //MousePointer.ShowOnCtrlKey();
            var handle = view.GetHandle();
            WinAPI.RegisterHotKey(handle, 1, ModifierKeys.NO_MODIFIER, VirtualKeyCodes.VK_HOME);

            if (generalOptionsRepository.Get(Setting.OpenControlCenterWhenProgramStarts, true))
            {
                MainForm.ControlCenter = ShowForm<ControlCenter>();
            }

            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var port))
            {
                try
                {
                    Server = new NetworkServer(listenerPort: port);
                    Server.DataArrived += DataArrivedEventHandler;
                    Server.Start();
                }
                catch (SocketException)
                {
                    Application.Restart();
                }

                view.TsslServerData.Text = $"{Server.Socket.LocalEndPoint} ({Lng.Elem("Listening on")}: {String.Join(", ", NetUtils.GetLocalIPAddresses(AddressFamily.InterNetwork))})";
            }

            LoadLanguage(2);
            LoadFirstMap();

            CheckLanguageFile();

            var templates = templateRepository.SelectAll();
            var templateToLoad = generalOptionsRepository.Get(Setting.AutoLoadedTemplate, String.Empty);
            var autoLoadTemplate = templates.FirstOrDefault(template => template.TemplateName == templateToLoad);
            if (autoLoadTemplate != null)
            {
                if (MainForm.ControlCenter == null)
                {
                    MainForm.ControlCenter = ShowForm<ControlCenter>();
                    MainForm.ControlCenter.StartTemplate(autoLoadTemplate);
                    MainForm.ControlCenter.Close();
                }
                else
                {
                    MainForm.ControlCenter.StartTemplate(autoLoadTemplate);
                }
            }
        }

        public void LoadLanguage(long userId)
        {
            var implementedLanguage = (ImplementedLanguage)personalOptionsRepository.Get(Setting.Language, userId, Constants.HungarianLanguageIndex);
            Lng.DefaultLanguage = Enum.TryParse(implementedLanguage.ToString(), out Mtf.LanguageService.Enums.Language selectedLanguage) ? selectedLanguage : Mtf.LanguageService.Enums.Language.Hungarian;
            LiveViewTranslator.Translate();
            Translator.Translate(view.GetSelf());
        }

        public static void SendMessageToSequenceOnDisplay(DisplayDto display, string message)
        {
            foreach (var sequenceProcess in SequenceProcesses)
            {
                if (sequenceProcess.Value.DisplayId == display.GetId())
                {
                    Server.SendMessageToClient(sequenceProcess.Value.Socket, message, true);
                }
            }
        }

        public static void SendMessageToFullScreenCamera(string message)
        {
            var info = GetFullScreenInfo();
            if (info.Key != null)
            {
                Server.SendMessageToClient(info.Key, message, true);
            }
        }

        private static KeyValuePair<Socket, CameraProcessInfo> GetFullScreenInfo()
        {
            foreach (KeyValuePair<Socket, CameraProcessInfo> cameraProcessInfo in CameraProcessInfo)
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
                var messages = $"{Server?.Encoding.GetString(e.Data)}";
                var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var message in allMessages)
                {
                    var messageParts = message.Split('|');

                    if (message.StartsWith($"{NetworkCommand.RegisterAgent}|"))
                    {
                        Agents.Add(messageParts[1]);
                        //AgentPingTimes.Add(messageParts[1], DateTime.UtcNow);
                        MainForm.ControlCenter?.RefreshAgents();
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterAgent}|"))
                    {
                        Agents.Remove(messageParts[1]);
                        //AgentPingTimes.Remove(messageParts[1]);
                        
                        //agentRepository.DeleteWhere(new { ServerIp = messageParts[1].Split(':')[0] });
                        MainForm.ControlCenter?.RefreshAgents();
                    }
                    else if (message.StartsWith($"{NetworkCommand.RegisterDisplay}|"))
                    {
                        var display = JsonSerializer.Deserialize<DisplayDto>(messageParts[1]);
                        DisplayManager.RemoteDisplays.Add(display);
                        if (MainForm.ControlCenter != null)
                        {
                            MainForm.ControlCenter.CachedDisplays = null;
                        }
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterDisplay}|"))
                    {
                        var display = JsonSerializer.Deserialize<DisplayDto>(messageParts[1]);
                        DisplayManager.RemoteDisplays.Remove(display);
                        if (MainForm.ControlCenter != null)
                        {
                            MainForm.ControlCenter.CachedDisplays = null;
                        }
                    }
                    else if (message.StartsWith($"{NetworkCommand.SendCameraProcessId}|"))
                    {
                        var cameraProcessId = Convert.ToInt32(messageParts[1]);
                        CameraProcesses.Add(e.Socket.LocalEndPoint.ToString(), cameraProcessId);
                    }
                    else if (message.StartsWith($"{NetworkCommand.RegisterSequence}|"))
                    {
                        var localEndPoint = messageParts[1];
                        SequenceProcesses.TryAdd(localEndPoint, new SequenceProcessInfo
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
                        SequenceProcesses.TryRemove(localEndPoint, out _);
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
                        VideoCaptureSources.Add(e.Socket, videoCaptureSources);
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
                        CameraProcessInfo.Add(e.Socket, new CameraProcessInfo
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
                        CameraProcessInfo.Remove(e.Socket);
                    }
                    else if (message.StartsWith($"{NetworkCommand.RegisterVideoSource}"))
                    {
                        CameraProcessInfo.Add(e.Socket, new CameraProcessInfo
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
                        CameraProcessInfo.Remove(e.Socket);
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
            var groupPermissions = rightRepository.SelectWhere(new { GroupId = groupId });
            var operationIds = groupPermissions.Select(gp => gp.OperationId).ToList();
            var operations = operationRepository.SelectWhere(new { Ids = operationIds });
            var assembly = typeof(CameraManagementPermissions).Assembly;

            foreach (var operation in operations)
            {
                var enumType = assembly.GetType($"Mtf.Permissions.Enums.{operation.PermissionGroup}");
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
                Server.Stop();
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
            }
        }

        private void MapLoader_VideoSourceObjectClicked(CustomEventArgs.VideoSourceObjectClickedEventArgs e)
        {
            if (MainForm.ControlCenter == null || MainForm.ControlCenter.IsDisposed)
            {
                MainForm.ControlCenter = ShowForm<ControlCenter>(null, e.VideoSource);
            }
            else
            {
                MainForm.ControlCenter.StartVideoSource(e.VideoSource);
            }
        }

        private void MapLoader_CameraObjectClicked(CustomEventArgs.CameraObjectClickedEventArgs e)
        {
            if (MainForm.ControlCenter == null || MainForm.ControlCenter.IsDisposed)
            {
                MainForm.ControlCenter = ShowForm<ControlCenter>(e.Camera);
            }
            else
            {
                MainForm.ControlCenter.StartCamera(e.Camera);
            }
        }

        public static void StopStartedApplications()
        {
            ProcessUtils.Kill(ControlCenterPresenter.CameraProcess);
            foreach (var cameraProcessInfo in CameraProcessInfo)
            {
                Server.SendMessageToClient(cameraProcessInfo.Key, NetworkCommand.Close.ToString());
            }
            foreach (var cameraProcess in CameraProcesses)
            {
                SentToClient(cameraProcess.Key, NetworkCommand.Kill, Core.Constants.CameraExe, cameraProcess.Value);
            }
            foreach (var sequenceProcess in SequenceProcesses)
            {
                Server.SendMessageToClient(sequenceProcess.Value.Socket, NetworkCommand.Close.ToString());
            }
        }

        public static void SentToClient(string clientAddress, params object[] parameters)
        {
            try
            {
                using (var clientSocket = CreateSocket(clientAddress))
                {
                    Server.SendMessageToClient(clientSocket, String.Join("|", parameters), true);
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
            MainForm.ControlCenter.SetImagesEnabledState();
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
            MainForm.ControlCenter.SetImagesEnabledState();
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
    }
}
