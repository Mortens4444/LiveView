using AxVIDEOCONTROL4Lib;
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
    public partial class ServerAndCameraManagement : BaseView, IServerAndCameraManagementView, IVideoServerView
    {
        private ServerAndCameraManagementPresenter presenter;

        public TreeView ServersAndCameras => tvServersAndCameras;

        public Button BtnNewCamera => btnNewCamera;

        public Button BtnModify => btnModify;

        public Button BtnRemove => btnRemove;

        public Button BtnProperties => btnProperties;

        public Button BtnMotionDetection => btnMotionDetection;

        public Button BtnSyncronize => btnSyncronize;

        public AxVideoServer AxVideoServer => axVideoServer;

        public ServerAndCameraManagement(IServiceProvider serviceProvider) : base(serviceProvider, typeof(ServerAndCameraManagementPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequireAnyPermission(ServerManagementPermissions.Select)]
        [RequireAnyPermission(CameraManagementPermissions.Select)]
        private void ServerAndCameraManagement_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as ServerAndCameraManagementPresenter;
            presenter.ChangeButtonStates(null);
            permissionManager.EnsurePermissions();
            presenter.Load();
        }

        [RequireAnyPermission(ServerManagementPermissions.Create | ServerManagementPermissions.Update)]
        private void BtnNewVideoServer_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowDialogWithReload<AddVideoServer>();
        }

        [RequireAnyPermission(DatabaseServerManagementPermissions.Create | DatabaseServerManagementPermissions.Update)]
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

        private void BtnProperties_Click(object sender, EventArgs e)
        {
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
            presenter?.ChangeButtonStates(e.Node);
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

            throw new NotSupportedException("SyncronizationMode is not supported yet.");
        }

        [RequireAnyPermission(CameraManagementPermissions.Update)]
        [RequireAnyPermission(ServerManagementPermissions.Update)]
        [RequireAnyPermission(DatabaseServerManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            presenter.Modify();
        }

        [RequireAnyPermission(CameraManagementPermissions.Delete)]
        [RequireAnyPermission(ServerManagementPermissions.Delete)]
        [RequireAnyPermission(DatabaseServerManagementPermissions.Delete)]
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
