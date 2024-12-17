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
        private readonly IDisplayPropertiesView view;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ILogger<DisplayProperties> logger;

        public DisplayPropertiesPresenter(IDisplayPropertiesView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IDisplayRepository<Display> displayRepository, ILogger<DisplayProperties> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.displayRepository = displayRepository;
            this.logger = logger;
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
