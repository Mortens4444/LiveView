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
    public partial class ServerAndCameraProperties : Form, IServerAndCameraPropertiesView
    {
        private readonly ServerAndCameraPropertiesPresenter serverAndCameraPropertiesPresenter;

        public ServerAndCameraProperties(PermissionManager permissionManager, ILogger<ServerAndCameraProperties> logger, IServerRepository<Sequence> serverRepository, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            serverAndCameraPropertiesPresenter = new ServerAndCameraPropertiesPresenter(this, serverRepository, cameraRepository, logger);

            Translator.Translate(this);
        }
    }
}
