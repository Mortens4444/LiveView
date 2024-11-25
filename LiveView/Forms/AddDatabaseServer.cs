using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddDatabaseServer : Form, IAddDatabaseServerView
    {
        private readonly AddDatabaseServerPresenter addDatabaseServerPresenter;

        public AddDatabaseServer(PermissionManager permissionManager, ILogger<AddDatabaseServer> logger, IDatabaseServerRepository<DatabaseServer> databaseServerRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            addDatabaseServerPresenter = new AddDatabaseServerPresenter(this, databaseServerRepository, logger);

            Translator.Translate(this);
        }
    }
}
