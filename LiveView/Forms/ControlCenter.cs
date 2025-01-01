using Database.Models;
using LiveView.Enums;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ControlCenter : BaseDisplayView, IControlCenterView
    {
        private ControlCenterPresenter presenter;
        private Process cameraProcess;

        public ControlCenter(IServiceProvider serviceProvider) : base(serviceProvider, typeof(ControlCenterPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);
            if (!permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.PanTilt))
            {
                btnMoveCameraNorthWest.Image = Properties.Resources.nw_g;
                btnMoveCameraNorthEast.Image = Properties.Resources.ne_g;
                btnMoveCameraSouthWest.Image = Properties.Resources.sw_g;
                btnMoveCameraSouthEast.Image = Properties.Resources.se_g;
                btnMoveCameraToPresetZero.Image = Properties.Resources.house_g;
            }

            if (!permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Pan))
            {
                btnMoveCameraEast.Image = Properties.Resources.e_g;
                btnMoveCameraSouth.Image = Properties.Resources.s_g;
            }

            if (!permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Tilt))
            {
                btnMoveCameraNorth.Image = Properties.Resources.n_g;
                btnMoveCameraWest.Image = Properties.Resources.w_g;
            }

            Translator.Translate(this);
        }

        public Point HomeLocation
        {
            get
            {
                if ((Location.X != -32000) && (Location.Y != -32000))
                {
                    return new Point(Location.X + pCrossHair.Location.X + pbCrossHair.Width / 2 + 5, Location.Y + pDisplays.Location.Y + pCrossHair.Location.Y + SystemInformation.CaptionHeight + pbCrossHair.Height / 2 + 3);
                }

                return new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            }
        }

        public Panel PDisplayDevices => pDisplayDevices;

        public ListView LvCameras => lvCameras;

        public ListView LvSequences => lvSequences;

        public ListView LvTemplates => lvTemplates;

        [RequirePermission(SequenceManagementPermissions.Close)]
        private void BtnCloseSequenceApplications_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CloseSequenceApplications();
        }

        [RequirePermission(CameraManagementPermissions.CloseFullScreen)]
        private void BtnCloseFullScreenCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CloseFullScreenCameraApplication();
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.IdentifyDisplays();
        }

        [RequirePermission(JoystickManagementPermissions.Calibrate)]
        private void BtnCalibrate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CalibrateJoystick();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnShowPreviousGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowPreviousGrid();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnPlayOrPauseSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.PlayOrPauseSequence();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnShowNextGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowNextGrid();
        }

        [RequirePermission(GridManagementPermissions.Rearrange)]
        private void BtnRearrangeGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RearrangeGrids();
        }

        [RequirePermission(CameraManagementPermissions.ZoomIn)]
        private void BtnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ZoomIn();
        }

        private void BtnZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopZoom();
        }

        [RequirePermission(CameraManagementPermissions.ZoomOut)]
        private void BtnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ZoomOut();
        }

        private void BtnZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopZoom();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraNorthWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToNorthWest();
        }

        private void BtnMoveCameraNorthWest_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void BtnMoveCameraNorth_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToNorth();
        }

        private void BtnMoveCameraNorth_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraNorthEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToNorthEast();
        }

        private void BtnMoveCameraNorthEast_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void BtnMoveCameraWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToWest();
        }

        private void BtnMoveCameraWest_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Preset)]
        private void BtnMoveCameraToPresetZero_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToPresetZero();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void BtnMoveCameraEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToEast();
        }

        private void BtnMoveCameraEast_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraSouthWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToSouthWest();
        }

        private void BtnMoveCameraSouthWest_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void BtnMoveCameraSouth_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToSouth();
        }

        private void BtnMoveCameraSouth_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraSouthEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveToSouthEast();
        }

        private void BtnMoveCameraSouthEast_MouseUp(object sender, MouseEventArgs e)
        {
            presenter.StopMoving();
        }

        private void ControlCenter_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as ControlCenterPresenter;
            GetAndCacheDisplays(PDisplayDevices.Size);
            presenter.Load();
        }

        private void PDisplayDevices_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DrawDisplays(e.Graphics, DisplayDrawingTools.Selected);
                DrawMouse(e.Graphics, PDisplayDevices.Size);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void LvSequences_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item.Tag is Sequence sequence)
            {
                AppStarter.Start("Sequence.exe", $"{permissionManager.CurrentUser.Id} {sequence.Id}");
            }
        }

        private void LvCameras_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item.Tag is Camera camera)
            {
                if (cameraProcess != null)
                {
                    cameraProcess.Kill();
                }
                cameraProcess = AppStarter.Start("Camera.exe", $"{permissionManager.CurrentUser.Id} {camera.Id}");
            }
        }

        private void PDisplayDevices_MouseClick(object sender, MouseEventArgs e)
        {
            presenter.SelectDisplay(e.Location);
        }
    }
}
