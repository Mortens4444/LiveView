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
    public partial class DisplayOptions : Form, IDisplayOptionsView
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
        private void Btn_ResetDisplays_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void Btn_Identify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(DisplayManagementPermissions.Update)]
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            displayOptionsPresenter.CloseForm();
        }
    }
}
