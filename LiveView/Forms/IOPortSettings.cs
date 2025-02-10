using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class IOPortSettings : BaseView, IIOPortSettingsView
    {
        private IOPortSettingsPresenter presenter;

        public CheckBox ChkZeroSignalled => chkZeroSignalled;

        public ComboBox CbIODevice => cbIODevice;

        public ComboBox CbOperationOrEvent => cbOperationOrEvent;

        public ComboBox CbOutputIOPort => cbOutputIOPort;

        public ListView LvIODevices => lvIODevices;

        public ListView LvIOPortRules => lvIOPortRules;

        public IOPortSettings(IServiceProvider serviceProvider) : base(serviceProvider, typeof(IOPortSettingsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(IODeviceManagementPermissions.Update)]
        private void BtnAddToRules_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddRule();
        }

        private void IOPortSettings_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as IOPortSettingsPresenter;
            presenter.Load();
        }

        private void ChangeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.ChangePortSettings();
        }

        [RequirePermission(IODeviceManagementPermissions.Update)]
        private void DeleteRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteRules();
        }
    }
}
