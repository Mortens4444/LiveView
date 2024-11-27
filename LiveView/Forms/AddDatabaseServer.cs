using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddDatabaseServer : Form, IAddDatabaseServerView
    {
        private readonly AddDatabaseServerPresenter addDatabaseServerPresenter;
        private readonly PermissionManager permissionManager;

        public AddDatabaseServer(PermissionManager permissionManager, ILogger<AddDatabaseServer> logger, IDatabaseServerRepository<DatabaseServer> databaseServerRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            addDatabaseServerPresenter = new AddDatabaseServerPresenter(this, databaseServerRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            addDatabaseServerPresenter.CloseForm();
        }
    }
}
