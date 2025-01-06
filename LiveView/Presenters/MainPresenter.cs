using Database.Interfaces;
using LiveView.Core.Enums.Keyboard;
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
using System.Windows.Forms;
using NetworkServer = Mtf.Network.Server;

namespace LiveView.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private IMainView view;
        private NetworkServer server;
        private readonly ILogger<MainForm> logger;
        private readonly Uptime uptime;
        private readonly IGroupRepository groupRepository;
        private readonly IUserRepository userRepository;
        private readonly IUsersInGroupsRepository userGroupRepository;

        public MainPresenter(MainPresenterDependencies mainPresenterDependencies)
            : base(mainPresenterDependencies)
        {
            logger = mainPresenterDependencies.Logger;
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
                server = new NetworkServer(listenerPort: port);
                server.DataArrived += DataArrivedEventHandler;
                server.Start();

                view.TsslServerData.Text = $"{server.Socket.LocalEndPoint} ({Lng.Elem("Listening on")}: {String.Join(", ", GetLocalIPAddresses())})";
            }
        }

        private IEnumerable<string> GetLocalIPAddresses()
        {
            return Dns.GetHostEntry(Dns.GetHostName())
                      .AddressList
                      .Where(ip => ip.AddressFamily == server.AddressFamily)
                      .Select(ip => ip.ToString());
        }

        private void DataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            var message = $"{server?.Encoding.GetString(e.Data)}";
            switch (message)
            {
                default:
                    DebugErrorBox.Show("Message arrived", message);
                    break;
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
