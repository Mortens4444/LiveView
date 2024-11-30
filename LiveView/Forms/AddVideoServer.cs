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
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddVideoServer : Form, IAddVideoServerView
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

        private void Btn_Validate_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void Btn_AddOrModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addVideoServerPresenter.AddOrModify(server);
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
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

        private void Cb_DNSNameOrIPAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hostDiscoveryResult = (HostDiscoveryResult)cb_DNSNameOrIPAddress.SelectedItem;
            tb_DisplayedName.Text = hostDiscoveryResult.Hostname;
            tb_MACAddress.Text = hostDiscoveryResult.MacAddress;
            tbManufacturer.Text = hostDiscoveryResult.Manufacturer;
        }

        public ServerDto GetServerDto()
        {
            return new ServerDto
            {
                IpAddress = cb_DNSNameOrIPAddress.Text,
                Hostname = tb_DisplayedName.Text,
                MacAddress = tb_MACAddress.Text,
                SerialNumber = tb_SziltechSN.Text,
                VideoServerCredentials = new Credentials
                {
                    UserName = tb_Username.Text,
                    Password = tb_Password.Password
                }
            };
        }

        public void AddToServerSelector(HostDiscoveryResult result)
        {
            Invoke((Action)(() =>
            {
                cb_DNSNameOrIPAddress.Items.Add(result);
            }));
        }

        public void LoadData(Server server)
        {
            if (server == null)
            {
                return;
            }

            cb_DNSNameOrIPAddress.Text = server.IpAddress;
            tb_DisplayedName.Text = server.Hostname;
            tb_MACAddress.Text = server.MacAddress;
            tb_SziltechSN.Text = server.SerialNumber;
            tb_Username.Text = server.Username;
            tb_Password.Text = server.Password;

            btn_AddOrModify.Text = Lng.Elem("Modify");
        }
    }
}
