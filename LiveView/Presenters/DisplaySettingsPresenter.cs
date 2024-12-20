using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class DisplaySettingsPresenter : BaseDisplayPresenter
    {
        private readonly IDisplaySettingsView view;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ILogger<DisplaySettings> logger;
        private readonly DisplayManager displayManager;

        public DisplaySettingsPresenter(IDisplaySettingsView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IDisplayRepository<Display> displayRepository, DisplayManager displayManager, ILogger<DisplaySettings> logger, FormFactory formFactory)
            : base(view, displayManager, generalOptionsRepository, formFactory)
        {
            this.view = view;
            this.displayManager = displayManager;
            this.displayRepository = displayRepository;
            this.logger = logger;
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
