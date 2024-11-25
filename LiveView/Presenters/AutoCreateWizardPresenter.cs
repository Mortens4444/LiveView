using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class AutoCreateWizardPresenter : BasePresenter
    {
        private readonly IAutoCreateWizardView autoCreateWizardView;
        private readonly ITemplateRepository<Template> templateRepository;
        private readonly ISequenceRepository<Sequence> sequenceRepository;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ILogger<AutoCreateWizard> logger;

        public AutoCreateWizardPresenter(IAutoCreateWizardView autoCreateWizardView, ITemplateRepository<Template> templateRepository,
            ISequenceRepository<Sequence> sequenceRepository, IGridRepository<Grid> gridRepository, ILogger<AutoCreateWizard> logger)
            : base(autoCreateWizardView)
        {
            this.autoCreateWizardView = autoCreateWizardView;
            this.templateRepository = templateRepository;
            this.sequenceRepository = sequenceRepository;
            this.gridRepository = gridRepository;
            this.logger = logger;
        }
    }
}
