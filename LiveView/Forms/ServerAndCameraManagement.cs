using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ServerAndCameraManagement : BaseView, IServerAndCameraManagementView
    {
        private readonly ServerAndCameraManagementPresenter serverAndCameraManagementPresenter;
        private readonly PermissionManager permissionManager;

        public TreeView ServersAndCameras => tvServersAndCameras;

        public ServerAndCameraManagement(PermissionManager permissionManager, ILogger<ServerAndCameraManagement> logger, FormFactory formFactory, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            btnNewCamera.Tag = nameof(BtnNewCamera_Click);
            btnNewVideoServer.Tag = nameof(BtnNewVideoServer_Click);
            permissionManager.ApplyPermissionsOnControls(this);

            serverAndCameraManagementPresenter = new ServerAndCameraManagementPresenter(formFactory, this, serverRepository, cameraRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void BtnNewCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.CreateNewCameraForm();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            serverAndCameraManagementPresenter.CloseForm();
        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void BtnNewVideoServer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            if (serverAndCameraManagementPresenter.ShowDialog<AddVideoServer>())
            {
                serverAndCameraManagementPresenter.Load();
            }
        }

        [RequirePermission(DatabaseServerManagementPermissions.Create)]
        private void BtnNewDBServer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            if (serverAndCameraManagementPresenter.ShowDialog<AddDatabaseServer>())
            {
                serverAndCameraManagementPresenter.Load();
            }
        }

        [RequirePermission(ServerManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.Modify();
        }

        [RequirePermission(ServerManagementPermissions.Delete)]
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.Remove();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        private void BtnProperties_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.ShowForm<ServerAndCameraProperties>();
        }

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void BtnMotionDetection_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.ShowForm<CameraMotionOptions>();
        }

        [RequirePermission(CameraManagementPermissions.Update)]
        private void BtnSyncronize_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.Syncronize();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        [RequirePermission(CameraManagementPermissions.Select)]
        private void ServerAndCameraManagement_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.Load();
        }
    }
}
