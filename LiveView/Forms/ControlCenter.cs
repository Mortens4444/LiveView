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
    public partial class ControlCenter : BaseView, IControlCenterView
    {
        private readonly ControlCenterPresenter controlCenterPresenter;
        private readonly PermissionManager permissionManager;

        public ControlCenter(PermissionManager permissionManager, ILogger<ControlCenter> logger, ITemplateRepository<Template> templateRepository, IDisplayRepository<Display> displayRepository, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            controlCenterPresenter = new ControlCenterPresenter(this, templateRepository, displayRepository, cameraRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(SequenceManagementPermissions.Close)]
        private void BtnCloseSequenceApplications_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.CloseSequenceApplications();
        }

        [RequirePermission(CameraManagementPermissions.CloseFullScreen)]
        private void BtnCloseFullScreenCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.CloseFullScreenCameraApplication();
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.IdentifyDisplays();
        }

        [RequirePermission(JoystickManagementPermissions.Calibrate)]
        private void BtnCalibrate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.CalibrateJoystick();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnShowPreviousGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.ShowPreviousGrid();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnPlayOrPauseSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.PlayOrPauseSequence();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void BtnShowNextGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.ShowNextGrid();
        }

        [RequirePermission(GridManagementPermissions.Rearrange)]
        private void BtnRearrangeGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.RearrangeGrids();
        }

        [RequirePermission(CameraManagementPermissions.ZoomIn)]
        private void BtnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.ZoomIn();
        }

        private void BtnZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopZoom();
        }

        [RequirePermission(CameraManagementPermissions.ZoomOut)]
        private void BtnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.ZoomOut();
        }

        private void BtnZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopZoom();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraNorthWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToNorthWest();
        }

        private void BtnMoveCameraNorthWest_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void BtnMoveCameraNorth_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToNorth();
        }

        private void BtnMoveCameraNorth_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraNorthEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToNorthEast();
        }

        private void BtnMoveCameraNorthEast_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void BtnMoveCameraWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToWest();
        }

        private void BtnMoveCameraWest_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Preset)]
        private void BtnMoveCameraToPresetZero_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToPresetZero();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void BtnMoveCameraEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToEast();
        }

        private void BtnMoveCameraEast_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraSouthWest_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToSouthWest();
        }

        private void BtnMoveCameraSouthWest_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void BtnMoveCameraSouth_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToSouth();
        }

        private void BtnMoveCameraSouth_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void BtnMoveCameraSouthEast_MouseDown(object sender, MouseEventArgs e)
        {
            permissionManager.EnsurePermissions();
            controlCenterPresenter.MoveToSouthEast();
        }

        private void BtnMoveCameraSouthEast_MouseUp(object sender, MouseEventArgs e)
        {
            controlCenterPresenter.StopMoving();
        }

        private void ControlCenter_Shown(object sender, EventArgs e)
        {
            controlCenterPresenter.Load();
        }
    }
}
