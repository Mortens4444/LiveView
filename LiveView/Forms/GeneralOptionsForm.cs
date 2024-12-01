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

namespace LiveView.Forms
{
    public partial class GeneralOptionsForm : BaseView, IGeneralOptionsView
    {
        private readonly GeneralOptionsPresenter generalOptionsPresenter;
        private readonly PermissionManager permissionManager;

        public GeneralOptionsForm(PermissionManager permissionManager, ILogger<GeneralOptionsForm> logger, IGeneralOptionsRepository<GeneralOptions> generalOptionsRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            generalOptionsPresenter = new GeneralOptionsPresenter(this, generalOptionsRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(DatabaseServerManagementPermissions.Update)]
        private void BtnChangeDatabaseDirectory_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.ChangeNosignalImage)]
        private void BtnNoSignalImageBrowse_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(SettingsManagementPermissions.UpdateStatic)]
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            generalOptionsPresenter.CloseForm();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void Btn_Default_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            generalOptionsPresenter.LoadDefaultSettings();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void Btn_Standard_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            generalOptionsPresenter.LoadStandardSettings();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void GeneralOptionsForm_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            generalOptionsPresenter.LoadSettings();
        }
    }
}
