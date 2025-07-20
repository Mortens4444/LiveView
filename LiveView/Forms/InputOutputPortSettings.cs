using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class InputOutputPortSettings : BaseView, IInputOutputPortSettingsView
    {
        private InputOutputPortSettingsPresenter presenter;

        public CheckBox ChkZeroSignalled => chkZeroSignalled;

        public ComboBox CbInputOutputDevice => cbInputOutputDevice;

        public ComboBox CbOperationOrEvent => cbOperationOrEvent;

        public ComboBox CbOutputInputOutputPort => cbOutputInputOutputPort;

        public ListView LvInputOutputDevices => lvInputOutputDevices;

        public ListView LvInputOutputPortRules => lvInputOutputPortRules;

        public InputOutputPortSettings(IServiceProvider serviceProvider) : base(serviceProvider, typeof(InputOutputPortSettingsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(IODeviceManagementPermissions.Select)]
        private void InputOutputPortSettings_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter = Presenter as InputOutputPortSettingsPresenter;
            presenter.Load();
        }

        [RequirePermission(IODeviceManagementPermissions.Update)]
        private void BtnAddToRules_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddRule();
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
