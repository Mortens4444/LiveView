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
    public partial class ControlCenter : Form, IControlCenterView
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
        private void Btn_CloseSequenceApplications_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.CloseFullScreen)]
        private void Btn_CloseFullScreenCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void Btn_Identify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.ZoomIn)]
        private void Btn_ZoomIn_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.ZoomOut)]
        private void Btn_ZoomOut_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(JoystickManagementPermissions.Calibrate)]
        private void Btn_Calibrate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void Btn_MoveCameraNorthWest_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void Btn_MoveCameraNorth_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void Btn_MoveCameraNorthEast_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void Btn_MoveCameraWest_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.Preset)]
        private void Btn_MoveCameraToPresetZero_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.Pan)]
        private void Btn_MoveCameraEast_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void Btn_MoveCameraSouthWest_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.Tilt)]
        private void Btn_MoveCameraSouth_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.PanTilt)]
        private void Btn_MoveCameraSouthEast_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void Btn_ShowPreviousGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void Btn_PlayOrPauseSequence_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void Btn_ShowNextGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GridManagementPermissions.Navigate)]
        private void Btn_RearrangeGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }
    }
}
