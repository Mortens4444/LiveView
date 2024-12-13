using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class SyncronView : BaseView, ISyncronViewView
    {
        private readonly SyncronViewPresenter syncronViewPresenter;
        private readonly PermissionManager permissionManager;

        public SyncronView(PermissionManager permissionManager, ILogger<SyncronView> logger, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            syncronViewPresenter = new SyncronViewPresenter(this, cameraRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnStepBack_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            syncronViewPresenter.StepBack();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnPause_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            syncronViewPresenter.Pause();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            syncronViewPresenter.Play();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnStepNext_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            syncronViewPresenter.StepNext();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnGoto_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            syncronViewPresenter.Goto();
        }

        private void TbSpeed_Scroll(object sender, EventArgs e)
        {
            syncronViewPresenter.SetSpeed();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void TsmiChangeCameraTo_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            syncronViewPresenter.ConnectToCamera();
        }
    }
}
