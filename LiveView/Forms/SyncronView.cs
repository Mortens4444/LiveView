using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class SyncronView : BaseView, ISyncronViewView
    {
        private SyncronViewPresenter presenter;

        public SyncronView(IServiceProvider serviceProvider) : base(serviceProvider, typeof(SyncronViewPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

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

        private void SyncronView_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as SyncronViewPresenter;
        }
    }
}
