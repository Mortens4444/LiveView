using AxVIDEOCONTROL4Lib;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Models.VideoServer;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddCameras : BaseView, IAddCamerasView, IVideoServerView
    {
        private readonly Server server;
        private readonly bool cameraLicenseRunnedOut;
        private readonly bool isSziltech;

        private readonly AddCamerasPresenter presenter;

        public ListView ServerCameras => lvCamerasOfServer;

        public ListView CamerasToView => lvCamerasToView;

        public ComboBox Servers => cbServers;

        public AddCameras(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<AddCameras> logger, ICameraRepository<Camera> cameraRepository, IServerRepository<Server> serverRepository, Server server = null)
             : base(permissionManager)
        {
            InitializeComponent();
            this.server = server;
            cameraLicenseRunnedOut = false;

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new AddCamerasPresenter(this, generalOptionsRepository, cameraRepository, serverRepository, logger);
            SetPresenter(presenter);

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
            presenter.LoadServers();
        }

        public AxVideoServer GetVideoServerControl()
        {
            return axVideoServer;
        }

        public bool CamerasToViewHasElementWithGuid(string guid)
        {
            return lvCamerasToView.HasElementWithGuid<VideoServerCamera>(guid);
        }
    }
}
