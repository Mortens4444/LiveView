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
    public partial class CameraMotionOptions : Form, ICameraMotionOptionsView
    {
        private readonly CameraMotionOptionsPresenter cameraMotionOptionsPresenter;

        public CameraMotionOptions(PermissionManager permissionManager, ILogger<CameraMotionOptions> logger, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            cameraMotionOptionsPresenter = new CameraMotionOptionsPresenter(this, cameraRepository, logger);

            Translator.Translate(this);
        }
    }
}
