using AxVIDEOCONTROL4Lib;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddCameras : BaseView, IAddCamerasView, IVideoServerView
    {
        private readonly VideoServer server;
        private readonly bool cameraLicenseRunnedOut;
        private readonly bool isSziltech;

        private AddCamerasPresenter presenter;

        public AxVideoServer AxVideoServer => axVideoServer;

        public ListView ServerCameras => lvCamerasOfServer;

        public ListView CamerasToView => lvCamerasToView;

        public ComboBox VideoServers => cbVideoServers;

        public AddCameras(IServiceProvider serviceProvider, VideoServer server = null) : base(serviceProvider, typeof(AddCamerasPresenter))
        {
            InitializeComponent();
            this.server = server;
            cameraLicenseRunnedOut = false;

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        private async void CbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            await presenter.GetCamerasAsync();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void BtnAddSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddSelectedCamera();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddAllCamera();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RemoveSelectedCamera();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RemoveAllCamera();
        }

        [RequirePermission(CameraManagementPermissions.Create | CameraManagementPermissions.Delete)]
        private void BtnAddCameras_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveCameras();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void AddCameras_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddCamerasPresenter;
            presenter.LoadServers(server);
        }

        public bool CamerasToViewHasElementWithGuid(string guid)
        {
            return lvCamerasToView.HasElementWithGuid(guid);
        }
    }
}
