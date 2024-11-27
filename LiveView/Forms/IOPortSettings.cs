using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class IOPortSettings : Form, IIOPortSettingsView
    {
        private readonly IOPortSettingsPresenter ioPortSettingsPresenter;
        private readonly PermissionManager permissionManager;

        public IOPortSettings(PermissionManager permissionManager, ILogger<IOPortSettings> logger, IIOPortRepository<IOPort> ioPortRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            ioPortSettingsPresenter = new IOPortSettingsPresenter(this, ioPortRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(IODeviceManagementPermissions.Update)]
        private void BtnAddToRules_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }
    }
}
