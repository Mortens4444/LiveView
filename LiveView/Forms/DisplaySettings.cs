using LiveView.Enums;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class DisplaySettings : BaseDisplayView, IDisplaySettingsView
    {
        private DisplaySettingsPresenter presenter;

        public Panel FullScreenDisplay => pFullscreenDisplay;

        public Panel FunctionChooser => pFunctionChooser;

        public DisplaySettings(IServiceProvider serviceProvider) : base(serviceProvider, typeof(DisplaySettingsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

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
            presenter = Presenter as DisplaySettingsPresenter;
            GetAndCacheDisplays(pFunctionChooser.Size);
            presenter.Load();
        }

        private void PFunctionChooser_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DrawDisplays(e.Graphics, DisplayDrawingTools.Functions);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void PFullscreenDisplay_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DrawDisplays(e.Graphics, DisplayDrawingTools.Fullscreen);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void PFunctionChooser_MouseClick(object sender, MouseEventArgs e)
        {
            presenter.ChangeDisplayFunction(e.Location);
        }

        private void PFullscreenDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            presenter.SelectFullscreenDisplay(e.Location);
        }
    }
}
