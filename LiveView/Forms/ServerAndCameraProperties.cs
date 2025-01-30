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
    public partial class ServerAndCameraProperties : BaseView, IServerAndCameraPropertiesView
    {
        private ServerAndCameraPropertiesPresenter presenter;

        public MtfListView LvCameraList => lvCameraList;

        public MtfListView LvHardwareInformation => lvHardwareInformation;

        public SaveFileDialog SaveFileDialog => saveFileDialog;

        public TextBox TbHost => tbHost;

        public TextBox TbPassword => tbVideoServerPassword;

        public TextBox TbVideoServerName => tbVideoServerName;

        public TextBox TbWindowsUsername => tbWindowsUsername;

        public TextBox TbWindowsPassword => tbWindowsPassword;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Server Server { get; private set; }

        public TextBox TbVideoServerUsername => tbVideoServerUsername;

        public TextBox TbVideoServerPassword => tbVideoServerPassword;

        public TextBox TbDongleSerial => tbDongleSerial;

        public TextBox TbDongleSubtype => tbDongleSubtype;

        public TextBox TbMacAddress => tbMacAddress;

        public TextBox TbModel => tbModel;

        public PictureBox PbPingTestStatus => pbPingTestStatus;

        public PictureBox PbRemoteVideoServerConnectionStatus => pbRemoteVideoServerConnectionStatus;

        public ImageList ImageList => imageList;

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

        [RequirePermission(ServerManagementPermissions.Select)]
        [RequirePermission(CameraManagementPermissions.Select)]
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Refresh();
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

        [RequirePermission(HardwareManagementPermissions.Select)]
        private void BtnGetHardwareInfo_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.GetHardwareInfo();
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
    }
}
