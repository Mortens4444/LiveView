using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class AutoCreateWizardPresenter
    {
        private readonly IAutoCreateWizardView autoCreateWizardView;
        private readonly ITemplateRepository templateRepository;
        private readonly ISequenceRepository sequenceRepository;
        private readonly IGridRepository gridRepository;

        public AutoCreateWizardPresenter(IAutoCreateWizardView autoCreateWizardView, ITemplateRepository templateRepository,
            ISequenceRepository sequenceRepository, IGridRepository gridRepository)
        {
            this.autoCreateWizardView = autoCreateWizardView;
            this.templateRepository = templateRepository;
            this.sequenceRepository = sequenceRepository;
            this.gridRepository = gridRepository;
        }
    }
}
