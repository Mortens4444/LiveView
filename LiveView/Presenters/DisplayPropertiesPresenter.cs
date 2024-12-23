using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class DisplayPropertiesPresenter : BasePresenter
    {
        private IDisplayPropertiesView view;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ILogger<DisplayProperties> logger;

        public DisplayPropertiesPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IDisplayRepository<Display> displayRepository, ILogger<DisplayProperties> logger)
            : base(generalOptionsRepository)
        {
            this.displayRepository = displayRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IDisplayPropertiesView;
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
