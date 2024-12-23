using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ControlCenter : BaseDisplayView, IControlCenterView
    {
        private ControlCenterPresenter presenter;

        public ControlCenter(IServiceProvider serviceProvider) : base(serviceProvider, typeof(ControlCenterPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

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
            presenter.Load();
        }

        private void PDisplayDevices_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                GetAndCacheDisplays(PDisplayDevices);
                DrawDisplays(e.Graphics);
                DrawMouse(e.Graphics, PDisplayDevices.Size);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }
    }
}
