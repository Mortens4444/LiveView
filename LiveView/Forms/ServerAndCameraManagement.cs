using Database.Enums;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ServerAndCameraManagement : BaseView, IServerAndCameraManagementView
    {
        private ServerAndCameraManagementPresenter presenter;

        public TreeView ServersAndCameras => tvServersAndCameras;

        public Button BtnModify => btnModify;

        public Button BtnRemove => btnRemove;

        public Button BtnProperties => btnProperties;

        public Button BtnMotionDetection => btnMotionDetection;

        public Button BtnSyncronize => btnSyncronize;

        public ServerAndCameraManagement(IServiceProvider serviceProvider) : base(serviceProvider, typeof(ServerAndCameraManagementPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        [RequirePermission(CameraManagementPermissions.Select)]
        private void ServerAndCameraManagement_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as ServerAndCameraManagementPresenter;
            presenter.ChangeButtonStates(null);
            permissionManager.EnsurePermissions();
            presenter.Load();
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

        [RequirePermission(CameraManagementPermissions.Create)]
        private void BtnNewCamera_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CreateNewCameraForm();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        private void BtnProperties_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowServerAndCameraProperties();
        }

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void BtnMotionDetection_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowForm<CameraMotionSettings>();
        }

        [RequirePermission(CameraManagementPermissions.Update)]
        private async void BtnSyncronize_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            await presenter.SyncronizeAsync();
        }

        private void TvServersAndCameras_AfterSelect(object sender, TreeViewEventArgs e)
        {
            presenter.ChangeButtonStates(e.Node);
        }

        public SyncronizationMode GetSyncronizationMode()
        {
            if (rbGuid.Checked)
            {
                return SyncronizationMode.Guid;
            }

            if (rbRecorderIndex.Checked)
            {
                return SyncronizationMode.RecorderIndex;
            }

            if (rbCameraName.Checked)
            {
                return SyncronizationMode.CameraName;
            }

            throw new NotImplementedException("SyncronizationMode  is not supported.");
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            presenter.Modify();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            presenter.Remove();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }
    }
}
