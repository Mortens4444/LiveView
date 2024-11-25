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
    public partial class AutoCreateWizard : Form, IAutoCreateWizardView
    {
        private readonly AutoCreateWizardPresenter autoCreateWizardPresenter;

        public AutoCreateWizard(PermissionManager permissionManager, ILogger<AutoCreateWizard> logger, ITemplateRepository<Template> templateRepository, ISequenceRepository<Sequence> sequenceRepository, IGridRepository<Grid> gridRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            autoCreateWizardPresenter = new AutoCreateWizardPresenter(this, templateRepository, sequenceRepository, gridRepository, logger);

            Translator.Translate(this);
        }
    }
}
