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
    public partial class ServerAndCameraProperties : BaseView, IServerAndCameraPropertiesView
    {
        private readonly ServerAndCameraPropertiesPresenter presenter;

        public ServerAndCameraProperties(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<ServerAndCameraProperties> logger, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new ServerAndCameraPropertiesPresenter(this, generalOptionsRepository, serverRepository, cameraRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(PasswordManagementPermissions.Select)]
        private void BtnShowPassword_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowPassword();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Refresh();
        }

        [RequirePermission(CameraManagementPermissions.ExportCameraList)]
        private void BtnExportCameraList_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ExportCameraList();
        }

        [RequirePermission(HardwareManagementPermissions.ExportInfo)]
        private void BtnExportHardwareInfo_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ExportHadwareInfo();
        }

        [RequirePermission(HardwareManagementPermissions.Select)]
        private void BtnGetHardwareInfo_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.GetHardwareInfo();
        }

        [RequirePermission(NetworkManagementPermissions.WakeOnLAN)]
        private void BtnWakeOnLan_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.WakeOnLan();
        }
    }
}
