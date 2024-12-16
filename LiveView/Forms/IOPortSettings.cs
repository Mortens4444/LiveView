using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class IOPortSettings : BaseView, IIOPortSettingsView
    {
        private readonly IOPortSettingsPresenter presenter;

        public IOPortSettings(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<IOPortSettings> logger, IIOPortRepository<IOPort> ioPortRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new IOPortSettingsPresenter(this, generalOptionsRepository, ioPortRepository, logger);
            SetPresenter(presenter);

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
            presenter.Load();
        }
    }
}
