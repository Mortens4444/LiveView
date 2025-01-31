using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class CameraMotionSettings : BaseView, ICameraMotionSettingsView
    {
        private CameraMotionOptionsPresenter presenter;

        public NumericUpDown NudMotionTrigger => nudMotionTrigger;

        public NumericUpDown NudMotionTriggerMinimumLength => nudMotionTriggerMinimumLength;

        public ComboBox CbPartnerVideoServer => cbPartnerVideoServer;

        public ComboBox CbPartnerCamera => cbPartnerCamera;

        public ListView LvCameras => lvCameras;

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

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void TsmiClearValues_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ClearMotionSettings();
        }
    }
}
