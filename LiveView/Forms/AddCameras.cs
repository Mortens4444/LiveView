using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddCameras : Form, IAddCamerasView
    {
        private readonly long serverId;
        private readonly bool cameraLicenseRunnedOut;
        private readonly bool isSziltech;
        private readonly PermissionManager permissionManager;

        private readonly AddCamerasPresenter addCamerasPresenter;

        public AddCameras(PermissionManager permissionManager, ILogger<AddCameras> logger, ICameraRepository<Camera> cameraRepository, long serverId)
        {
            InitializeComponent();
            this.serverId = serverId;
            this.permissionManager = permissionManager;
            cameraLicenseRunnedOut = false;

            permissionManager.ApplyPermissionsOnControls(this);

            addCamerasPresenter = new AddCamerasPresenter(this, cameraRepository, logger);

            Translator.Translate(this);
        }

        private void Cb_ServerDisplayedName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lv_CamerasOfServer_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {

        }

        private void Btn_AddSelected_Click(object sender, EventArgs e)
        {
        }

        private void Btn_AddAll_Click(object sender, EventArgs e)
        {
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void Btn_RemoveSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void Btn_RemoveAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void Btn_AddCameras_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            addCamerasPresenter.CloseForm();
        }
    }
}
