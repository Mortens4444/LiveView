using Database.Models;
using LiveView.Core.Services.PasswordHashers;
using LiveView.Interfaces;
using LiveView.Models.Network;
using LiveView.Presenters;
using Mtf.Extensions.Services;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddVideoServer : BaseView, IAddVideoServerView
    {
        private readonly Server server;
        private AddVideoServerPresenter presenter;

        public TextBox TbModel => tbModel;

        public TextBox TbSziltechSerialNumber => tbSziltechSerialNumber;

        public AddVideoServer(IServiceProvider serviceProvider, Server server = null) : base(serviceProvider, typeof(AddVideoServerPresenter))
        {
            InitializeComponent();
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

        public ServerDto GetServerDto()
        {
            return new ServerDto
            {
                IpAddress = cbIpAddress.Text,
                Hostname = tbHostname.Text,
                MacAddress = tbMacAddress.Text,
                SerialNumber = tbSziltechSerialNumber.Text,
                VideoServerCredentials = new Credentials
                {
                    Username = tbUsername.Text,
                    Password = VideoServerPasswordCryptor.Encrypt(tbPassword.Password)
                },
                WindowsCredentials = new Credentials
                {
                    Username = tbWinUsername.Text,
                    Password = WindowsPasswordCryptor.Encrypt(tbWinPassword.Password)
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

        public void LoadData(Server server)
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
            tbPassword.Password = VideoServerPasswordCryptor.Decrypt(server.Password);
            tbWinUsername.Text = server.WinUser;
            tbWinPassword.Password = WindowsPasswordCryptor.Decrypt(server.WinPass);
        }
    }
}
