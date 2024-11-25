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
    public partial class Templates : Form, ITemplatesView
    {
        private readonly TemplatesPresenter templatesPresenter;

        public Templates(PermissionManager permissionManager, ILogger<Templates> logger, ITemplateRepository<Template> templateRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            templatesPresenter = new TemplatesPresenter(this, templateRepository, logger);

            Translator.Translate(this);
        }
    }
}
