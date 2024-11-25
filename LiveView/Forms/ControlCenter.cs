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
    public partial class ControlCenter : Form, IControlCenterView
    {
        private readonly ControlCenterPresenter controlCenterPresenter;

        public ControlCenter(PermissionManager permissionManager, ILogger<ControlCenter> logger, ITemplateRepository<Template> templateRepository, IDisplayRepository<Display> displayRepository, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            controlCenterPresenter = new ControlCenterPresenter(this, templateRepository, displayRepository, cameraRepository, logger);

            Translator.Translate(this);
        }
    }
}
