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
    public partial class CameraProperties : Form, ICameraPropertiesView
    {
        private readonly CameraPropertiesPresenter cameraPropertiesPresenter;

        public CameraProperties(PermissionManager permissionManager, ILogger<CameraProperties> logger, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            cameraPropertiesPresenter = new CameraPropertiesPresenter(this, cameraRepository, logger);

            Translator.Translate(this);
        }
    }
}
