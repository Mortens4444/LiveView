using Database.Models;
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

        public TextBox TbHttpStream => tbHttpStream;

        public NumericUpDown NudStreamId => nudStreamId;

        public NumericUpDown NudPresetNumber => nudPresetNumber;

        public NumericUpDown NudPatternNumber => nudPatternNumber;

        public ComboBox CbFullscreenMode => cbFullscreenMode;
        
        public ComboBox CbPresetName => cbPresetName;

        public ComboBox CbPatternName => cbPatternName;

        public CameraProperties(IServiceProvider serviceProvider, Camera camera) : base(serviceProvider, typeof(CameraPropertiesPresenter))
        {
            InitializeComponent();
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
    }
}
