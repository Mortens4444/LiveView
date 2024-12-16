using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class IOPortSettingsPresenter : BasePresenter
    {
        private readonly IIOPortSettingsView ioPortSettingsView;
        private readonly IIOPortRepository<IOPort> ioPortRepository;
        private readonly ILogger<IOPortSettings> logger;

        public IOPortSettingsPresenter(IIOPortSettingsView ioPortSettingsView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IIOPortRepository<IOPort> ioPortRepository, ILogger<IOPortSettings> logger)
            : base(ioPortSettingsView, generalOptionsRepository)
        {
            this.ioPortSettingsView = ioPortSettingsView;
            this.ioPortRepository = ioPortRepository;
            this.logger = logger;
        }

        public void AddRule()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
