using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class AddDatabaseServer : BaseView, IAddDatabaseServerView
    {
        private readonly AddDatabaseServerPresenter presenter;

        public AddDatabaseServer(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<AddDatabaseServer> logger, IDatabaseServerRepository<DatabaseServer> databaseServerRepository)
             : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new AddDatabaseServerPresenter(this, generalOptionsRepository, databaseServerRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(ServerManagementPermissions.Create)]
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddDatabaseServer();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }
    }
}
