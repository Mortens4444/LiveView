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
        private readonly IIOPortSettingsView view;
        private readonly IIOPortRepository<IOPort> ioPortRepository;
        private readonly ILogger<IOPortSettings> logger;

        public IOPortSettingsPresenter(IIOPortSettingsView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IIOPortRepository<IOPort> ioPortRepository, ILogger<IOPortSettings> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
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
