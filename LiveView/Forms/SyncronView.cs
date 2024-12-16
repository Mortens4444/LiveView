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
        private readonly SyncronViewPresenter presenter;

        public SyncronView(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<SyncronView> logger, ICameraRepository<Camera> cameraRepository) : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new SyncronViewPresenter(this, generalOptionsRepository, cameraRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnStepBack_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.StepBack();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnPause_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Pause();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Play();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnStepNext_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.StepNext();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnGoto_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Goto();
        }

        private void TbSpeed_Scroll(object sender, EventArgs e)
        {
            presenter.SetSpeed();
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void TsmiChangeCameraTo_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ConnectToCamera();
        }
    }
}
