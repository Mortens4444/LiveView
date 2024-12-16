using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Models.Network;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class AddVideoServer : BaseView, IAddVideoServerView
    {
        private readonly Server server;
        private readonly AddVideoServerPresenter presenter;

        public AddVideoServer(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<AddVideoServer> logger, IServerRepository<Server> serverRepository, Server server = null)
             : base(permissionManager)
        {
            InitializeComponent();
            this.server = server;

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new AddVideoServerPresenter(this, generalOptionsRepository, serverRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            presenter.Validate();
        }

        [RequirePermission(ServerManagementPermissions.Create)]
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
            permissionManager.EnsurePermissions();
            presenter.LoadData(server);
            await presenter.SearchForHostsAsync();
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
