using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Models.Network;
using LiveView.Presenters;
using LiveView.Services.Network;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddVideoServer : Form, IAddVideoServerView
    {
        private readonly AddVideoServerPresenter addVideoServerPresenter;
        private readonly PermissionManager permissionManager;

        public AddVideoServer(PermissionManager permissionManager, ILogger<AddVideoServer> logger, IServerRepository<Server> serverRepository)
        {
            InitializeComponent();
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
            addVideoServerPresenter.Add();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            addVideoServerPresenter.CloseForm();
        }

        [RequirePermission(ServerManagementPermissions.Select)]
        private async void AddVideoServer_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            HostDiscoveryService.HostDiscovered += OnHostDiscovered;
            await Task.Run(HostDiscoveryService.Discovery);
            HostDiscoveryService.HostDiscovered -= OnHostDiscovered;
        }

        private void OnHostDiscovered(HostDiscoveryResult result)
        {
            Invoke((Action)(() =>
            {
                cb_DNSNameOrIPAddress.Items.Add(result);
            }));
        }

        private void Cb_DNSNameOrIPAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hostDiscoveryResult = (HostDiscoveryResult)cb_DNSNameOrIPAddress.SelectedItem;
            tb_DisplayedName.Text = hostDiscoveryResult.Hostname;
            tb_MACAddress.Text = hostDiscoveryResult.MacAddress;
            tbManufacturer.Text = hostDiscoveryResult.Manufacturer;
        }

        public ServerDto GetServer()
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
    }
}
