using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class IOPortSettingsPresenter : BasePresenter
    {
        private readonly IIOPortSettingsView ioPortSettingsView;
        private readonly IIOPortRepository<IOPort> ioPortRepository;
        private readonly ILogger<IOPortSettings> logger;

        public IOPortSettingsPresenter(IIOPortSettingsView ioPortSettingsView, IIOPortRepository<IOPort> ioPortRepository, ILogger<IOPortSettings> logger)
            : base(ioPortSettingsView)
        {
            this.ioPortSettingsView = ioPortSettingsView;
            this.ioPortRepository = ioPortRepository;
            this.logger = logger;
        }
    }
}
