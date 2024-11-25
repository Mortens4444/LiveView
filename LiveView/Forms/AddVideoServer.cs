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
    public partial class AddVideoServer : Form, IAddVideoServerView
    {
        private readonly AddVideoServerPresenter addVideoServerPresenter;

        public AddVideoServer(PermissionManager permissionManager, ILogger<AddVideoServer> logger, IServerRepository<Sequence> serverRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            addVideoServerPresenter = new AddVideoServerPresenter(this, serverRepository, logger);

            Translator.Translate(this);
        }
    }
}
