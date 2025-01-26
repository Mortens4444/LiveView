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
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public readonly static Dictionary<string, (Socket socket, int processId, long sequenceId, long displayId)> SequenceProcesses = new Dictionary<string, (Socket socket, int processId, long sequenceId, long displayId)>();
        public readonly static Dictionary<Socket, CameraProcessInfo> CameraProcessInfo = new Dictionary<Socket, CameraProcessInfo>();

        public static NetworkServer Server { get; private set; }
        private readonly Dictionary<int, List<byte[]>> imageParts = new Dictionary<int, List<byte[]>>();
        private readonly Dictionary<int, int> totalPartsMap = new Dictionary<int, int>();
        private readonly ILogger<MainForm> logger;
        private readonly Uptime uptime;
        private readonly IServiceProvider serviceProvider;
        private readonly IMapRepository mapRepository;
        private readonly IMapObjectRepository mapObjectRepository;
        private readonly IDisplayRepository displayRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IRightRepository rightRepository;
        private readonly IUserRepository userRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IAgentRepository agentRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly IUsersInGroupsRepository userGroupRepository;

        private IMainView view;
        private MapLoader mapLoader;
        //private KBD300A kBD300A = new KBD300A("COM1");

        public MainPresenter(MainPresenterDependencies mainPresenterDependencies)
            : base(mainPresenterDependencies)
        {
            logger = mainPresenterDependencies.Logger;
            rightRepository = mainPresenterDependencies.RightRepository;
            serviceProvider = mainPresenterDependencies.ServiceProvider;
            mapRepository = mainPresenterDependencies.MapRepository;
            mapObjectRepository = mainPresenterDependencies.MapObjectRepository;
            displayRepository = mainPresenterDependencies.DisplayRepository;
            groupRepository = mainPresenterDependencies.GroupRepository;
            userRepository = mainPresenterDependencies.UserRepository;
            userGroupRepository = mainPresenterDependencies.UserGroupRepository;
            personalOptionsRepository = mainPresenterDependencies.PersonalOptionsRepository;
            permissionManager = mainPresenterDependencies.PermissionManager;
            agentRepository = mainPresenterDependencies.AgentRepository;
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

            var implementedLanguage = (ImplementedLanguage)personalOptionsRepository.Get(Setting.Language, permissionManager.CurrentUser.Id, Constants.HungarianLanguageIndex);
            Lng.DefaultLanguage = Enum.TryParse(implementedLanguage.ToString(), out Mtf.LanguageService.Enums.Language selectedLanguage) ? selectedLanguage : Mtf.LanguageService.Enums.Language.Hungarian;
            LiveViewTranslator.Translate();
            Translator.Translate(view.GetSelf());
            LoadFirstMap();

            CheckLanguageFile();
        }

        public static void SendMessageToFullScreenCamera(string message)
        {
            var info = MainPresenter.GetFullScreenInfo();
            if (info.Key != null)
            {
                MainPresenter.Server.SendMessageToClient(info.Key, message, true);
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
                        ControlCenterPresenter.Agents.Add(messageParts[1]);
                        MainForm.ControlCenter?.RefreshAgents();
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterAgent}|"))
                    {
                        ControlCenterPresenter.Agents.Remove(messageParts[1]);
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
                        //var userId = Convert.ToInt64(messageParts[2]);
                        var sequenceId = Convert.ToInt64(messageParts[3]);
                        var displayId = Convert.ToInt64(messageParts[4]);
                        //var isMdi = Convert.ToBoolean(messageParts[5]);
                        var processId = Convert.ToInt32(messageParts[6]);
                        SequenceProcesses.Add(localEndPoint, (e.Socket, processId, sequenceId, displayId));
                    }
                    else if (message.StartsWith($"{NetworkCommand.UnregisterSequence}|"))
                    {
                        var localEndPoint = messageParts[1];
                        //var sequenceId = Convert.ToInt64(messageParts[2]);
                        //var processId = Convert.ToInt32(messageParts[3]);
                        SequenceProcesses.Remove(localEndPoint);
                    }
                    else if (message.StartsWith($"{NetworkCommand.VideoCaptureSourcesResponse}|"))
                    {
                        var videoCaptureSources = messageParts[1].Split(';')
                            .Select(vcs => vcs.Split('='))
                            .ToDictionary(vcs => vcs[0], vcs => vcs[1]);
                        VideoCaptureSources.Add(e.Socket, videoCaptureSources);
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
            var result = new Mtf.Permissions.Models.User<User>();
            var user = userRepository.Login(view.TbUsername.Text, view.TbPassword.Text);
            var groupIds = userGroupRepository.SelectWhere(new { UserId = user.Id }).Select(userGroup => userGroup.GroupId);

            result.Username = user.Username;
            result.Tag = user;
            result.Groups = new List<Mtf.Permissions.Models.Group>();
            foreach (var groupId in groupIds)
            {
                var group = new Mtf.Permissions.Models.Group();
                var groupPermissions = rightRepository.SelectWhere(new { GroupId = groupId });
                result.Groups.Add(group);
            }

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

            return result;
        }

        public void SecondaryLogon(int neededSecondaryLogonPriority)
        {
            var secondaryUser = userRepository.SecondaryLogin(view.TbUsername2.Text, view.TbPassword2.Text);
            if (secondaryUser.SecondaryLogonPriority < neededSecondaryLogonPriority)
            {
                var message = String.Format(UserShouldHaveAtLeastPriority, secondaryUser, neededSecondaryLogonPriority);
                ShowError(message);
            }
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
                var (socket, sequenceProcessId, _, _) = sequenceProcess.Value;
                Server.SendMessageToClient(socket, NetworkCommand.Close.ToString());
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
    }
}
