using Database.Models;
using Database.Services.PasswordHashers;
using LiveView.Interfaces;
using LiveView.Models.Network;
using LiveView.Presenters;
using Mtf.LanguageService;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Network;
using Mtf.Network.Interfaces;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class AddDatabaseServer : BaseView, IAddDatabaseServerView
    {
        private readonly DatabaseServer databaseServer;
        private AddDatabaseServerPresenter presenter;

        public AddDatabaseServer(IServiceProvider serviceProvider, DatabaseServer databaseServer = null) : base(serviceProvider, typeof(AddDatabaseServerPresenter))
        {
            InitializeComponent();
            this.databaseServer = databaseServer;

            permissionManager.ApplyPermissionsOnControls(this);

            if (databaseServer != null)
            {
                Text = Lng.Elem("Add Video Server");
                btnAddOrModify.Text = "Modify";
            }
            Translator.Translate(this);
        }

        [RequireAnyPermission(DatabaseServerManagementPermissions.Create | DatabaseServerManagementPermissions.Update)]
        private void BtnAddOrModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddDatabaseOrModifyServer(databaseServer);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(DatabaseServerManagementPermissions.Select)]
        private async void AddDatabaseServer_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddDatabaseServerPresenter;
            permissionManager.EnsurePermissions();
            presenter.LoadData(databaseServer);
            await presenter.SearchForHostsAsync();
        }

        public DatabaseServerDto GetDatabaseServerDto()
        {
            return new DatabaseServerDto
            {
                IpAddress = cbIpAddress.Text,
                Hostname = tbHostname.Text,
                MacAddress = tbMacAddress.Text,
                DatabaseName = tbDatabaseName.Text,
                DatabaseServerPort = (int)nudDatabaseServerPort.Value,
                DatabaseServerCredentials = new Credentials
                {
                    Username = DatabaseServerPasswordCryptor.UsernameEncrypt(tbUsername.Text),
                    Password = String.IsNullOrEmpty(tbPassword.Password) ? databaseServer?.EncryptedPassword : DatabaseServerPasswordCryptor.PasswordEncrypt(tbPassword.Password)
                }
            };
        }

        public void LoadData(DatabaseServer server)
        {
            if (server == null)
            {
                return;
            }

            cbIpAddress.Text = server.IpAddress;
            tbHostname.Text = server.Hostname;
            tbMacAddress.Text = server.MacAddress;
            tbDatabaseName.Text = server.DbName;
            tbUsername.Text = server.Username;
        }

        public void AddToServerSelector(HostDiscoveryResult result)
        {
            Invoke((Action)(() =>
            {
                cbIpAddress.Items.Add(result);
            }));
        }
    }
}
