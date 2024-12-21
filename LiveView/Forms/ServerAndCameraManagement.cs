using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ServerAndCameraManagement : BaseView, IServerAndCameraManagementView
    {
        private readonly ServerAndCameraManagementPresenter presenter;

        public TreeView ServersAndCameras => tvServersAndCameras;

        public ServerAndCameraManagement(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<ServerAndCameraManagement> logger, FormFactory formFactory, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            btnNewCamera.Tag = nameof(BtnNewCamera_Click);
            btnNewVideoServer.Tag = nameof(BtnNewVideoServer_Click);
            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new ServerAndCameraManagementPresenter(formFactory, this, generalOptionsRepository, serverRepository, cameraRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void BtnNewCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CreateNewCameraForm();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void BtnNewVideoServer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowDialogWithReload<AddVideoServer>();
        }

        [RequirePermission(DatabaseServerManagementPermissions.Create)]
        private void BtnNewDBServer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowDialogWithReload<AddDatabaseServer>();
        }

        [RequirePermission(ServerManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Modify();
        }

        [RequirePermission(ServerManagementPermissions.Delete)]
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Remove();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        private void BtnProperties_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<ServerAndCameraProperties>();
        }

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void BtnMotionDetection_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<CameraMotionSettings>();
        }

        [RequirePermission(CameraManagementPermissions.Update)]
        private void BtnSyncronize_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Syncronize();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        [RequirePermission(CameraManagementPermissions.Select)]
        private void ServerAndCameraManagement_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Load();
        }
    }
}
