using Database.Interfaces;
using Database.Models;
using LanguageService;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Models.Network;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class AddVideoServer : BaseView, IAddVideoServerView
    {
        private readonly Server server;
        private readonly AddVideoServerPresenter addVideoServerPresenter;
        private readonly PermissionManager permissionManager;

        public AddVideoServer(PermissionManager permissionManager, ILogger<AddVideoServer> logger, IServerRepository<Server> serverRepository, Server server = null)
        {
            InitializeComponent();
            this.server = server;
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            addVideoServerPresenter = new AddVideoServerPresenter(this, serverRepository, logger);

            Translator.Translate(this);
        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            addVideoServerPresenter.Validate();
        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void BtnAddOrModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addVideoServerPresenter.AddOrModify(server);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            addVideoServerPresenter.CloseForm();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        private async void AddVideoServer_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addVideoServerPresenter.LoadData(server);
            await addVideoServerPresenter.SearchForHostsAsync();
        }

        private void CbIpAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hostDiscoveryResult = (HostDiscoveryResult)cbIpAddress.SelectedItem;
            tbDisplayedName.Text = hostDiscoveryResult.Hostname;
            tbMacAddress.Text = hostDiscoveryResult.MacAddress;
            tbManufacturer.Text = hostDiscoveryResult.Manufacturer;
        }

        public ServerDto GetServerDto()
        {
            return new ServerDto
            {
                IpAddress = cbIpAddress.Text,
                Hostname = tbDisplayedName.Text,
                MacAddress = tbMacAddress.Text,
                SerialNumber = tbSziltechSerialNumber.Text,
                VideoServerCredentials = new Credentials
                {
                    UserName = tbUsername.Text,
                    Password = tbPassword.Password
                }
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
            tbDisplayedName.Text = server.Hostname;
            tbMacAddress.Text = server.MacAddress;
            tbSziltechSerialNumber.Text = server.SerialNumber;
            tbUsername.Text = server.Username;
            tbPassword.Text = server.Password;

            btnAddOrModify.Text = Lng.Elem("Modify");
        }
    }
}
