using Database.Models;
using Database.Services.PasswordHashers;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService;
using Mtf.LanguageService.Windows.Forms;
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

        private void AddDatabaseServer_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddDatabaseServerPresenter;
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
    }
}
