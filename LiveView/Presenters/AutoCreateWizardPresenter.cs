using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class AutoCreateWizardPresenter : BasePresenter
    {
        private readonly IAutoCreateWizardView view;
        private readonly ITemplateRepository<Template> templateRepository;
        private readonly ISequenceRepository<Sequence> sequenceRepository;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ILogger<AutoCreateWizard> logger;

        public AutoCreateWizardPresenter(IAutoCreateWizardView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ITemplateRepository<Template> templateRepository,
            ISequenceRepository<Sequence> sequenceRepository, IGridRepository<Grid> gridRepository, ILogger<AutoCreateWizard> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.templateRepository = templateRepository;
            this.sequenceRepository = sequenceRepository;
            this.gridRepository = gridRepository;
            this.logger = logger;
        }

        public void AddAll()
        {
            throw new NotImplementedException();
        }

        public void AddSelected()
        {
            throw new NotImplementedException();
        }

        public void AutoCreate()
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveSelected()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
