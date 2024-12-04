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
        private readonly IDisplayOptionsView displayOptionsView;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ILogger<DisplayOptions> logger;

        public DisplayOptionsPresenter(IDisplayOptionsView displayOptionsView, IDisplayRepository<Display> displayRepository, ILogger<DisplayOptions> logger)
            : base(displayOptionsView)
        {
            this.displayOptionsView = displayOptionsView;
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
