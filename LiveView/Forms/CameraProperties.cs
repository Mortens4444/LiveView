using Database.Models;
using Database.Services;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class CameraProperties : BaseView, ICameraPropertiesView
    {
        private CameraPropertiesPresenter presenter;

        public Camera Camera { get; }

        public TextBox TbCameraName => tbCameraName;

        public TextBox TbCameraGuid => tbCameraGuid;

        public TextBox TbCameraIpAddress => tbCameraIpAddress;

        public TextBox TbCameraUsername => tbCameraUsername;

        public PasswordBox TbCameraPassword => tbCameraPassword;

        public TextBox TbStreamUrl => tbStreamUrl;

        public NumericUpDown NudStreamId => nudStreamId;

        public NumericUpDown NudPresetNumber => nudPresetNumber;

        public NumericUpDown NudPatternNumber => nudPatternNumber;

        public ComboBox CbCameraFunctionType => cbCameraFunctionType;

        public ComboBox CbFullscreenMode => cbFullscreenMode;

        public ComboBox CbPresetName => cbPresetName;

        public ComboBox CbPatternName => cbPatternName;

        public TextBox TbCameraFunctionCallback => tbCameraFunctionCallback;

        public TextBox TbCameraFunctionCallbackParameters => tbCameraFunctionCallbackParameters;

        public MtfListView LvCameraFunctions => lvCameraFunctions;

        public OpenFileDialog OpenFileDialog => openFileDialog;

        public SaveFileDialog SaveFileDialog => saveFileDialog;

        public ComboBox CbVideoSources => cbVideoSource;

        public Label LblVideoSources => lblVideoSource;

        public PictureBox PbStreamUrl => pbStreamUrl;

        public CameraProperties(IServiceProvider serviceProvider, Camera camera) : base(serviceProvider, typeof(CameraPropertiesPresenter))
        {
            InitializeComponent();
            tbCameraPassword.ShowRealPasswordLength = AppConfig.GetBoolean(Database.Constants.ProtectPasswordLength);
            Camera = camera;

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Save();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void CameraProperties_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as CameraPropertiesPresenter;
            presenter.Load();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            presenter.ShowSearchCameraUrlForm();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            presenter.AddNewCameraFunction();
        }

        private void TsmiDeleteCameraFunction_Click(object sender, EventArgs e)
        {
            presenter.DeleteSelectedCameraFunctions();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            presenter.ExportCustomFunctions();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            presenter.ImportCustomFunctions();
        }

        private void TbStreamUrl_TextChanged(object sender, EventArgs e)
        {
            presenter.CreateQuickResponseCode();
        }
    }
}
