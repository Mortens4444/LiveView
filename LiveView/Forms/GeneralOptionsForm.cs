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
    public partial class GeneralOptionsForm : BaseView, IGeneralOptionsView
    {
        private readonly GeneralOptionsPresenter presenter;

        public GeneralOptionsForm(PermissionManager permissionManager, ILogger<GeneralOptionsForm> logger, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository)
             : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new GeneralOptionsPresenter(this, generalOptionsRepository, logger);
            SetPresenter(presenter);

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
            presenter.SelectNoSignalImage();
        }

        [RequirePermission(SettingsManagementPermissions.UpdateStatic)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveSettings();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void BtnDefault_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.LoadDefaultSettings();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void BtnStandard_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.LoadStandardSettings();
        }

        [RequirePermission(SettingsManagementPermissions.SelectStatic)]
        private void GeneralOptionsForm_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Load();
        }
    }
}
