using LiveView.Forms;
using LiveView.Interfaces;
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
        private readonly IMainView mainView;
        private readonly ILogger<MainForm> logger;

        public MainPresenter(FormFactory formFactory, IMainView mainView, ILogger<MainForm> logger)
            : base(mainView, formFactory)
        {
            this.mainView = mainView;
            this.logger = logger;
        }

        public override void Load()
        {
            MousePointer.ShowOnCtrlKey();
            var handle = mainView.GetHandle();
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
            if (mainView.ShowConfirm(Lng.Elem("Confirmation"), Lng.Elem("Are you sure you want to exit?"), Decide.No))
            {
                Environment.Exit(0);
                var handle = mainView.GetHandle();
                WinAPI.UnregisterHotKey(handle, 1);
                return true;
            }
            return false;
        }

        public void SetCursorPosition()
        {
            mainView.SetCursorPosition();
            SendKeys.Send("^");
        }
    }
}
