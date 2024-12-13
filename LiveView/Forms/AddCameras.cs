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
        private readonly PermissionManager permissionManager;

        private readonly AddCamerasPresenter addCamerasPresenter;

        public ListView ServerCameras => lvCamerasOfServer;

        public ListView CamerasToView => lvCamerasToView;

        public ComboBox Servers => cbServers;

        public AddCameras(PermissionManager permissionManager, ILogger<AddCameras> logger, ICameraRepository<Camera> cameraRepository, IServerRepository<Server> serverRepository, Server server = null)
        {
            InitializeComponent();
            this.server = server;
            this.permissionManager = permissionManager;
            cameraLicenseRunnedOut = false;

            permissionManager.ApplyPermissionsOnControls(this);

            addCamerasPresenter = new AddCamerasPresenter(this, cameraRepository, serverRepository, logger);

            Translator.Translate(this);
        }

        private async void CbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            await addCamerasPresenter.GetCamerasAsync();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void BtnAddSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.AddSelectedCamera();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.AddAllCamera();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.RemoveSelectedCamera();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.RemoveAllCamera();
        }

        [RequirePermission(CameraManagementPermissions.Create | CameraManagementPermissions.Delete)]
        private void BtnAddCameras_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.SaveCameras();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            addCamerasPresenter.CloseForm();
        }

        private void AddCameras_Shown(object sender, EventArgs e)
        {
            addCamerasPresenter.LoadServers();
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
