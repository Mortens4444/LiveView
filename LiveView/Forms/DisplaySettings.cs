using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class DisplaySettings : BaseDisplayView, IDisplaySettingsView
    {
        private readonly DisplaySettingsPresenter presenter;

        public Panel FullScreenDisplay => pFullscreenDisplay;

        public Panel FunctionChooser => pFunctionChooser;

        public DisplaySettings(FormFactory formFactory, PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IDisplayRepository<Display> displayRepository, DisplayManager displayManager, ILogger<DisplaySettings> logger) : base(displayManager, permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new DisplaySettingsPresenter(this, generalOptionsRepository, displayRepository, displayManager, logger, formFactory);
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

        private void DisplaySettings_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }

        private void PFunctionChooser_Paint(object sender, PaintEventArgs e)
        {
            PanelPaint(pFunctionChooser, e);
        }

        private void PFullscreenDisplay_Paint(object sender, PaintEventArgs e)
        {
            PanelPaint(pFullscreenDisplay, e);
        }

        private void PanelPaint(Panel panel, PaintEventArgs e)
        {
            try
            {
                GetAndCacheDisplays(panel);
                DrawDisplays(e.Graphics);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void PFunctionChooser_MouseClick(object sender, MouseEventArgs e)
        {
            presenter.ChangeDisplay(false, e.X, e.Y);
        }

        private void PFullscreenDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            presenter.ChangeDisplay(true, e.X, e.Y);
        }
    }
}
