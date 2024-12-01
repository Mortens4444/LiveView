using AxVIDEOCONTROL4Lib;
using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Models.VideoServer;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
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

        public ListView ServerCameras => lv_CamerasOfServer;

        public ListView CamerasToView => lv_CamerasToView;

        public ComboBox Servers => cb_Servers;

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

        private async void Cb_Servers_SelectedIndexChanged(object sender, EventArgs e)
        {
            await addCamerasPresenter.GetCamerasAsync();
        }

        private void Lv_CamerasOfServer_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {

        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void Btn_AddSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.AddSelectedCamera();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void Btn_AddAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.AddAllCamera();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void Btn_RemoveSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.RemoveSelectedCamera();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void Btn_RemoveAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.RemoveAllCamera();
        }

        [RequirePermission(CameraManagementPermissions.Create | CameraManagementPermissions.Delete)]
        private void Btn_AddCameras_Click(object sender, EventArgs e)
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
            return lv_CamerasToView.HasElementWithGuid<VideoServerCamera>(guid);
        }
    }
}
