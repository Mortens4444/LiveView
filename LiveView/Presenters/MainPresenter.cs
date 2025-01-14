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
using Mtf.LanguageService;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Enums;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;
using NetworkServer = Mtf.Network.Server;

namespace LiveView.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private IMainView view;
        private readonly ILogger<MainForm> logger;
        private readonly Uptime uptime;
        private readonly IServiceProvider serviceProvider;
        private readonly IMapRepository mapRepository;
        private readonly IMapObjectRepository mapObjectRepository;
        private readonly IDisplayRepository displayRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IUserRepository userRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly PermissionManager permissionManager;
        private readonly IUsersInGroupsRepository userGroupRepository;

        public readonly static Dictionary<string, int> CameraProcesses = new Dictionary<string, int>();
        public readonly static Dictionary<string, (Socket socket, int processId, long sequenceId, long displayId)> SequenceProcesses = new Dictionary<string, (Socket socket, int processId, long sequenceId, long displayId)>();
        //public readonly static Dictionary<string, (int processId, long sequenceId, long displayId)> SequenceProcesses = new Dictionary<string, (int processId, long sequenceId, long displayId)>();
        //public readonly static Dictionary<Socket, (int processId, long sequenceId, long displayId)> SequenceProcesses = new Dictionary<Socket, (int processId, long sequenceId, long displayId)>();

        public static NetworkServer Server;

        public MainPresenter(MainPresenterDependencies mainPresenterDependencies)
            : base(mainPresenterDependencies)
        {
            logger = mainPresenterDependencies.Logger;
            serviceProvider = mainPresenterDependencies.ServiceProvider;
            mapRepository = mainPresenterDependencies.MapRepository;
            mapObjectRepository = mainPresenterDependencies.MapObjectRepository;
            displayRepository = mainPresenterDependencies.DisplayRepository;
            groupRepository = mainPresenterDependencies.GroupRepository;
            userRepository = mainPresenterDependencies.UserRepository;
            userGroupRepository = mainPresenterDependencies.UserGroupRepository;
            personalOptionsRepository = mainPresenterDependencies.PersonalOptionsRepository;
            permissionManager = mainPresenterDependencies.PermissionManager;
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
            Mtf.LanguageService.Enums.Language selectedLanguage;
            Lng.DefaultLanguage = Enum.TryParse(implementedLanguage.ToString(), out selectedLanguage) ? selectedLanguage : Mtf.LanguageService.Enums.Language.Hungarian;
            LiveViewTranslator.Translate();
            Translator.Translate(view.GetSelf());
            LoadMap(); // ToDo: Sometimes it fails to load.

            CheckLanguageFile();
        }

        private void CheckLanguageFile()
        {
            var hash = Hasher.GetFileSha256Hash(Path.Combine(Application.StartupPath, "Languages.ods"));
            if (hash != "2c31421f94e6c7928028481e1b640c8c2cf714310981b2dea23774721803a8a9")
            {
                ShowInfo("The language file has been tampered.");
            }
        }

        private void DataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            var message = $"{Server?.Encoding.GetString(e.Data)}";
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
                MainForm.ControlCenter.CachedDisplays = null;
            }
            else if (message.StartsWith($"{NetworkCommand.UnregisterDisplay}|"))
            {
                var display = JsonSerializer.Deserialize<DisplayDto>(messageParts[1]);
                DisplayManager.RemoteDisplays.Remove(display);
                MainForm.ControlCenter.CachedDisplays = null;
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
                //SequenceProcesses.Add(localEndPoint, (processId, sequenceId, displayId));
                //SequenceProcesses.Add(e.Socket, (processId, sequenceId, displayId));
                SequenceProcesses.Add(localEndPoint, (e.Socket, processId, sequenceId, displayId));
            }
            else if (message.StartsWith($"{NetworkCommand.UnregisterSequence}|"))
            {
                var localEndPoint = messageParts[1];
                //var sequenceId = Convert.ToInt64(messageParts[2]);
                //var processId = Convert.ToInt32(messageParts[3]);
                if (SequenceProcesses.ContainsKey(localEndPoint))
                {
                    SequenceProcesses.Remove(localEndPoint);
                }
                //if (SequenceProcesses.ContainsKey(e.Socket))
                //{
                //    SequenceProcesses.Remove(e.Socket);
                //}
            }
            else
            {
                DebugErrorBox.Show("Unknown message arrived", message);
            }
        }

        public void PrimaryLogon()
        {
            throw new NotImplementedException();
        }

        public void SecondaryLogon()
        {
            throw new NotImplementedException();
        }

        public void MoveMouseToHome()
        {
            SendKeys.Send("{HOME}");
        }

        public bool Exit()
        {
            if (view.ShowConfirm(Lng.Elem("Confirmation"), Lng.Elem("Are you sure you want to exit?"), Decide.No))
            {
                Environment.Exit(0);
                var handle = view.GetHandle();
                WinAPI.UnregisterHotKey(handle, 1);
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

        private void LoadMap()
        {
            var maps = mapRepository.SelectAll();
            if (maps.Any())
            {
                var map = MapDto.FromModel(maps.First());
                map.MapObjects = mapObjectRepository.SelectWhere(new { map.Id }).Select(MapObjectDto.FromModel).ToArray();
                var mapLoader = (MapLoader)ActivatorUtilities.CreateInstance(serviceProvider, typeof(MapLoader), view.PbMap, view.TtHint);
                mapLoader.LoadMap(map);
            }
        }
    }
}
