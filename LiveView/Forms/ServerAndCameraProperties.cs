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
    public partial class ServerAndCameraProperties : BaseView, IServerAndCameraPropertiesView
    {
        private readonly ServerAndCameraPropertiesPresenter serverAndCameraPropertiesPresenter;
        private readonly PermissionManager permissionManager;

        public ServerAndCameraProperties(PermissionManager permissionManager, ILogger<ServerAndCameraProperties> logger, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            serverAndCameraPropertiesPresenter = new ServerAndCameraPropertiesPresenter(this, serverRepository, cameraRepository, logger);

            Translator.Translate(this);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            serverAndCameraPropertiesPresenter.CloseForm();
        }

        [RequirePermission(PasswordManagementPermissions.Select)]
        private void BtnShowPassword_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.ExportCameraList)]
        private void BtnExportCameraList_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(HardwareManagementPermissions.ExportInfo)]
        private void BtnExportHardwareInfo_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(HardwareManagementPermissions.Select)]
        private void BtnGetHardwareInfo_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(NetworkManagementPermissions.WakeOnLAN)]
        private void Btn_WakeOnLAN_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }
    }
}
