using AxVIDEOCONTROL4Lib;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class SyncronView : BaseView, ISyncronViewView
    {
        private SyncronViewPresenter presenter;

        public AxVideoPicture AxVideoPicture1 => axVideoPlayerWindow1.AxVideoPicture;

        public AxVideoPicture AxVideoPicture2 => axVideoPlayerWindow2.AxVideoPicture;

        public AxVideoPicture AxVideoPicture3 => axVideoPlayerWindow3.AxVideoPicture;

        public AxVideoPicture AxVideoPicture4 => axVideoPlayerWindow4.AxVideoPicture;

        public TrackBar TbSpeed => tbSpeed;

        public DateTimePicker DtpImageDate => dtpImageDate;

        public NumericUpDown NudHour => nudImageHour;

        public NumericUpDown NudMinute => nudImageMinute;

        public NumericUpDown NudSecond => nudImageSecond;

        public CheckBox ChkOsd => chkOsd;

        public ToolStripMenuItem TsmiChangeCameraTo => tsmiChangeCameraTo;

        public SyncronView(IServiceProvider serviceProvider) : base(serviceProvider, typeof(SyncronViewPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);
            AxVideoPicture1.Visible = false;
            AxVideoPicture2.Visible = false;
            AxVideoPicture3.Visible = false;
            AxVideoPicture4.Visible = false;
            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnStepBack_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.StepBack();
        }

        [RequirePermission(CameraManagementPermissions.Pause)]
        private void BtnPause_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Pause();
        }

        [RequirePermission(CameraManagementPermissions.Play)]
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Play();
        }

        [RequirePermission(CameraManagementPermissions.Next)]
        private void BtnStepNext_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.StepNext();
        }

        [RequirePermission(CameraManagementPermissions.GoTo)]
        private void BtnGoto_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Goto();
        }

        private void TbSpeed_Scroll(object sender, EventArgs e)
        {
            presenter.SetSpeed();
        }

        private void SyncronView_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as SyncronViewPresenter;
            presenter.Load();
        }

        private void ChkOsd_CheckedChanged(object sender, EventArgs e)
        {
            presenter.ChangeOsdState();
        }
    }
}
