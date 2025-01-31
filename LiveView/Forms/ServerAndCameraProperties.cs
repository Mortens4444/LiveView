using AxVIDEOCONTROL4Lib;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ServerAndCameraProperties : BaseView, IServerAndCameraPropertiesView, IVideoServerView
    {
        private ServerAndCameraPropertiesPresenter presenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Server Server { get; private set; }

        public MtfListView LvCameraList => lvCameraList;

        public MtfListView LvHardwareInformation => lvHardwareInformation;

        public SaveFileDialog SaveFileDialog => saveFileDialog;

        public TextBox TbHost => tbHost;

        public TextBox TbPassword => tbVideoServerPassword;

        public TextBox TbVideoServerName => tbVideoServerName;

        public TextBox TbWindowsUsername => tbWindowsUsername;

        public TextBox TbWindowsPassword => tbWindowsPassword;

        public TextBox TbVideoServerUsername => tbVideoServerUsername;

        public TextBox TbVideoServerPassword => tbVideoServerPassword;

        public TextBox TbDongleSerial => tbDongleSerial;

        public TextBox TbDongleSubtype => tbDongleSubtype;

        public TextBox TbMacAddress => tbMacAddress;

        public TextBox TbModel => tbModel;

        public PictureBox PbPingTestStatus => pbPingTestStatus;

        public PictureBox PbRemoteVideoServerConnectionStatus => pbRemoteVideoServerConnectionStatus;

        public ImageList ImageList => imageList;

        public Label LblPingTestStatus => lblPingTestStatus;

        public Label LblRemoteVideoServerConnectionStatus => lblRemoteVideoServerConnectionStatus;

        public TextBox TbVideoServerErrorMessage => tbVideoServerErrorMessage;

        public TextBox TbManufacturer => tbManufacturer;

        public AxVideoServer AxVideoServer => axVideoServer;

        public TextBox TbReturnCode => tbReturnCode;

        public TextBox TbVideoServerTime => tbVideoServerTime;

        public TextBox TbRecorderVersion => tbRecorderVersion;

        public TextBox TbRemoteVideoServerVersion => tbRemoteVideoServerVersion;

        public TextBox TbVideoRecorderProtocolVersion => tbVideoRecorderProtocolVersion;

        public TextBox TbRecorderStatus => tbRecorderStatus;

        public TextBox TbCpuUsage => tbCpuUsage;

        public TextBox TbRecordingInterval => tbRecordingInterval;

        public TextBox TbRecordedLocalCameraNumber => tbRecordedLocalCameraNumber;

        public TextBox TbLicensedCameraNumber => tbLicensedCameraNumber;

        public TextBox TbLiveViewDisplay => tbLiveViewDisplay;

        public TextBox TbWindowErrorMessage => tbWindowErrorMessage;

        public PictureBox PbWindowsConnectionStatus => pbWindowsConnectionStatus;

        public TextBox TbRecording => tbRecording;

        public ServerAndCameraProperties(IServiceProvider serviceProvider, Server server) : base(serviceProvider, typeof(ServerAndCameraPropertiesPresenter))
        {
            InitializeComponent();
            Server = server;

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        private void ServerAndCameraProperties_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as ServerAndCameraPropertiesPresenter;
            presenter.Load();
        }

        [RequirePermission(PasswordManagementPermissions.Select)]
        private void BtnShowPassword_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowPassword();
        }

        [RequirePermission(CameraManagementPermissions.ExportCameraList)]
        private void BtnExportCameraList_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ExportCameraList();
        }

        [RequirePermission(HardwareManagementPermissions.ExportInfo)]
        private void BtnExportHardwareInfo_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ExportHadwareInfo();
        }

        [RequirePermission(NetworkManagementPermissions.WakeOnLAN)]
        private void BtnWakeOnLan_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.WakeOnLAN();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(PasswordManagementPermissions.Select)]
        private void BtnShowWinPassword_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowWinPassword();
        }
    }
}
