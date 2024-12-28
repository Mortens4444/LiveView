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
        private IAutoCreateWizardView view;
        private readonly ITemplateRepository<Template> templateRepository;
        private readonly ISequenceRepository<Sequence> sequenceRepository;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ILogger<AutoCreateWizard> logger;

        public AutoCreateWizardPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ITemplateRepository<Template> templateRepository,
            ISequenceRepository<Sequence> sequenceRepository, IGridRepository<Grid> gridRepository, ILogger<AutoCreateWizard> logger)
            : base(generalOptionsRepository)
        {
            this.templateRepository = templateRepository;
            this.sequenceRepository = sequenceRepository;
            this.gridRepository = gridRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAutoCreateWizardView;
        }

        public void AddAll()
        {
            AddAllItemsFromListViewToAnother(view.LeftSide, view.RightSide, (item) => view.HasItemWithId(view.RightSide, ((IHaveId<long>)item.Tag).Id));
        }

        public void AddSelected()
        {
            AddSelectedItemsFromListViewToAnother(view.LeftSide, view.RightSide, (item) => view.HasItemWithId(view.RightSide, ((IHaveId<long>)item.Tag).Id));
        }

        public void AutoCreate()
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            view.RemoveAllItem(view.RightSide);
        }

        public void RemoveSelected()
        {
            view.RemoveSelectedItems(view.RightSide);
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
