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
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ServerAndCameraManagement : Form, IServerAndCameraManagementView
    {
        private readonly ServerAndCameraManagementPresenter serverAndCameraManagementPresenter;
        private readonly PermissionManager permissionManager;

        private const int ServerIconIndex = 1;
        private const int CameraIconIndex = 2;
        private const int UpdateServerIconIndex = 3;
        private const int UpdateCameraIconIndex = 4;
        private const int DeleteServerIconIndex = 5;
        private const int DeleteCameraIconIndex = 6;
        private const int DatabaseServerIconIndex = 7;

        public ServerAndCameraManagement(PermissionManager permissionManager, ILogger<ServerAndCameraManagement> logger, FormFactory formFactory, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            btn_NewCamera.Tag = nameof(Btn_NewCamera_Click);
            btn_NewVideoServer.Tag = nameof(Btn_NewVideoServer_Click);
            permissionManager.ApplyPermissionsOnControls(this);

            serverAndCameraManagementPresenter = new ServerAndCameraManagementPresenter(formFactory, this, serverRepository, cameraRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void Btn_NewCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.CreateNewCameraForm();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            serverAndCameraManagementPresenter.CloseForm();
        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void Btn_NewVideoServer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            if (serverAndCameraManagementPresenter.ShowDialog<AddVideoServer>())
            {
                serverAndCameraManagementPresenter.Load();
            }
        }

        [RequirePermission(DatabaseServerManagementPermissions.Create)]
        private void Btn_NewDBServer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.ShowForm<AddDatabaseServer>();
        }

        [RequirePermission(ServerManagementPermissions.Update)]
        private void Btn_Modify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.ModifyServer();
        }

        [RequirePermission(ServerManagementPermissions.Delete)]
        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.RemoveServer();

        }

        [RequirePermission(ServerManagementPermissions.Select)]
        private void Btn_Properties_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.ShowForm<ServerAndCameraProperties>();
        }

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void Btn_MotionDetection_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            serverAndCameraManagementPresenter.ShowForm<CameraMotionOptions>();
        }

        [RequirePermission(CameraManagementPermissions.Update)]
        private void Btn_Syncronize_Click(object sender, EventArgs e)
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

        public void AddServer(Server server)
        {
            tv_ServersAndCameras.Nodes["Servers"].Nodes.Add(new TreeNode(server.Hostname, ServerIconIndex, ServerIconIndex) { Name = server.Id.ToString(), Tag = server });
        }
    }
}
