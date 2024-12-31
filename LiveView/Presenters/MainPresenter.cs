using Database.Interfaces;
using Database.Models;
using LiveView.Core.Enums.Keyboard;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Enums.Keyboard;
using Mtf.LanguageService;
using Mtf.MessageBoxes.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private IMainView view;
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
