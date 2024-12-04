using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class AddDatabaseServer : BaseView, IAddDatabaseServerView
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
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addDatabaseServerPresenter.AddDatabaseServer();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            addDatabaseServerPresenter.CloseForm();
        }
    }
}
