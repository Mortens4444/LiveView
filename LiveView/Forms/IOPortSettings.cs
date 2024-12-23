using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class IOPortSettings : BaseView, IIOPortSettingsView
    {
        private IOPortSettingsPresenter presenter;

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
    }
}
