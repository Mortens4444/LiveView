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
    public partial class DisplaySettings : BaseView, IDisplayOptionsView
    {
        private readonly DisplayOptionsPresenter presenter;

        public DisplaySettings(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<DisplaySettings> logger, IDisplayRepository<Display> displayRepository) : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new DisplayOptionsPresenter(this, generalOptionsRepository, displayRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(DisplayManagementPermissions.Update)]
        private void BtnResetDisplays_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ResetDisplays();
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.IdentifyDisplays();
        }

        [RequirePermission(DisplayManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveDisplaySettings();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void DisplayOptions_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }
    }
}
