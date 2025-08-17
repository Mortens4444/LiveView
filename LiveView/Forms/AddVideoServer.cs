using Database.Models;
using Database.Services;
using Database.Services.PasswordHashers;
using LiveView.Dto;
using LiveView.Interfaces;
using LiveView.Models.Network;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddVideoServer : BaseView, IAddVideoServerView
    {
        private readonly VideoServer server;
        private AddVideoServerPresenter presenter;

        public TextBox TbModel => tbModel;

        public TextBox TbSziltechSerialNumber => tbSziltechSerialNumber;

        public AddVideoServer(IServiceProvider serviceProvider, VideoServer server = null) : base(serviceProvider, typeof(AddVideoServerPresenter))
        {
            InitializeComponent();
            tbPassword.ShowRealPasswordLength = AppConfig.GetBoolean(Database.Constants.ProtectPasswordLength);
            tbWinPassword.ShowRealPasswordLength = tbPassword.ShowRealPasswordLength;

            this.server = server;

            permissionManager.ApplyPermissionsOnControls(this);

            if (server != null)
            {
                Text = "Modify video server";
                btnAddOrModify.Text = "Modify";
            }
            Translator.Translate(this);
        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            presenter.Validate();
        }

        [RequireAnyPermission(ServerManagementPermissions.Create | ServerManagementPermissions.Update)]
        private void BtnAddOrModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddOrModify(server);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        private async void AddVideoServer_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddVideoServerPresenter;
            permissionManager.EnsurePermissions();
            presenter.LoadData(server);
            await presenter.SearchForHostsAsync();
        }

        private void CbIpAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hostDiscoveryResult = (HostDiscoveryResult)cbIpAddress.SelectedItem;
            tbHostname.Text = hostDiscoveryResult.Hostname;
            tbMacAddress.Text = hostDiscoveryResult.MacAddress;
            tbManufacturer.Text = hostDiscoveryResult.Manufacturer;
        }

        public VideoServerDto GetServerDto()
        {
            return new VideoServerDto
            {
                IpAddress = cbIpAddress.Text,
                Hostname = tbHostname.Text,
                MacAddress = tbMacAddress.Text,
                SerialNumber = tbSziltechSerialNumber.Text,
                VideoServerCredentialsId = server?.VideoServerCredentialsId ?? 0,
                WindowsCredentialsId = server?.WindowsCredentialsId ?? 0,
                VideoServerCredentials = new Credentials
                {
                    Username = VideoServerPasswordCryptor.UsernameEncrypt(tbUsername.Text),
                    Password = String.IsNullOrEmpty(tbPassword.Password) ? server?.EncryptedPassword : VideoServerPasswordCryptor.PasswordEncrypt(tbPassword.Password)
                },
                WindowsCredentials = new Credentials
                {
                    Username = WindowsPasswordCryptor.UsernameEncrypt(tbWinUsername.Text),
                    Password = String.IsNullOrEmpty(tbWinPassword.Password) ? server?.EncryptedWinPass: WindowsPasswordCryptor.PasswordEncrypt(tbWinPassword.Password)
                },
            };
        }

        public void AddToServerSelector(HostDiscoveryResult result)
        {
            Invoke((Action)(() =>
            {
                cbIpAddress.Items.Add(result);
            }));
        }

        public void LoadData(VideoServer server)
        {
            if (server == null)
            {
                return;
            }

            cbIpAddress.Text = server.IpAddress;
            tbHostname.Text = server.Hostname;
            tbMacAddress.Text = server.MacAddress;
            tbSziltechSerialNumber.Text = server.SerialNumber;
            tbUsername.Text = server.Username;
            tbWinUsername.Text = server.WinUser;
        }
    }
}
