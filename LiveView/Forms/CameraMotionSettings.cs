using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class CameraMotionSettings : BaseView, ICameraMotionSettingsView
    {
        private CameraMotionOptionsPresenter presenter;

        public CameraMotionSettings(IServiceProvider serviceProvider) : base(serviceProvider, typeof(CameraMotionOptionsPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void BtnChange_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveSettings();
        }

        private void CameraMotionOptions_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as CameraMotionOptionsPresenter;
            presenter.Load();
        }
    }
}
