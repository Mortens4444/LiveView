using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class IOPortSettingsPresenterDependencies : BasePresenterDependencies
    {
        public IOPortSettingsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IEventRepository eventRepository,
            IIOPortRepository ioPortRepository,
            IIOPortsRuleRepository iOPortsRuleRepository,
            IIOPortsLogRepository iOPortsLogRepository,
            ILogger<IOPortSettings> logger)
            : base(generalOptionsRepository)
        {
            EventRepository = eventRepository;
            IOPortRepository = ioPortRepository;
            IOPortsRuleRepository = iOPortsRuleRepository;
            IOPortsLogRepository = iOPortsLogRepository;
            Logger = logger;
        }

        public IIOPortsRuleRepository IOPortsRuleRepository { get; private set; }

        public IIOPortsLogRepository IOPortsLogRepository { get; private set; }

        public IIOPortRepository IOPortRepository { get; private set; }

        public ILogger<IOPortSettings> Logger { get; private set; }

        public IEventRepository EventRepository { get; private set; }
    }
}
