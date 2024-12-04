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
    public partial class DisplayOptions : BaseView, IDisplayOptionsView
    {
        private readonly DisplayOptionsPresenter displayOptionsPresenter;
        private readonly PermissionManager permissionManager;

        public DisplayOptions(PermissionManager permissionManager, ILogger<DisplayOptions> logger, IDisplayRepository<Display> displayRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            displayOptionsPresenter = new DisplayOptionsPresenter(this, displayRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(DisplayManagementPermissions.Update)]
        private void BtnResetDisplays_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            displayOptionsPresenter.ResetDisplays();
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            displayOptionsPresenter.IdentifyDisplays();
        }

        [RequirePermission(DisplayManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            displayOptionsPresenter.SaveDisplaySettings();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            displayOptionsPresenter.CloseForm();
        }

        private void DisplayOptions_Shown(object sender, EventArgs e)
        {
            displayOptionsPresenter.Load();
        }
    }
}
