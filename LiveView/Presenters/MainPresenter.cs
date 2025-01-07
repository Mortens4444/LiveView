using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Keyboard;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Enums;
using Mtf.Network.EventArg;
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
        private IMainView view;
        private readonly ILogger<MainForm> logger;
        private readonly Uptime uptime;
        private readonly IDisplayRepository displayRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IUserRepository userRepository;
        private readonly IUsersInGroupsRepository userGroupRepository;

        public static NetworkServer Server;

        public MainPresenter(MainPresenterDependencies mainPresenterDependencies)
            : base(mainPresenterDependencies)
        {
            logger = mainPresenterDependencies.Logger;
            displayRepository = mainPresenterDependencies.DisplayRepository;
            groupRepository = mainPresenterDependencies.GroupRepository;
            userRepository = mainPresenterDependencies.UserRepository;
            userGroupRepository = mainPresenterDependencies.UserGroupRepository;
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
                Server = new NetworkServer(listenerPort: port);
                Server.DataArrived += DataArrivedEventHandler;
                Server.Start();

                view.TsslServerData.Text = $"{Server.Socket.LocalEndPoint} ({Lng.Elem("Listening on")}: {String.Join(", ", NetUtils.GetLocalIPAddresses(AddressFamily.InterNetwork))})";
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
            }
            else if (message.StartsWith($"{NetworkCommand.UnregisterDisplay}|"))
            {
                var display = JsonSerializer.Deserialize<DisplayDto>(messageParts[1]);
                DisplayManager.RemoteDisplays.Remove(display);
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
    }
}
