using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class DisplayOptionsPresenter : BasePresenter
    {
        private readonly IDisplayOptionsView view;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ILogger<DisplaySettings> logger;

        public DisplayOptionsPresenter(IDisplayOptionsView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IDisplayRepository<Display> displayRepository, ILogger<DisplaySettings> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.displayRepository = displayRepository;
            this.logger = logger;
        }

        public void IdentifyDisplays()
        {
            throw new NotImplementedException();
        }

        public void ResetDisplays()
        {
            throw new NotImplementedException();
        }

        public void SaveDisplaySettings()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
