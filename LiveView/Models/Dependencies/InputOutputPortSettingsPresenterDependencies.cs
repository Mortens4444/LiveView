using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class InputOutputPortSettingsPresenterDependencies : BasePresenterDependencies
    {
        public InputOutputPortSettingsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IUserEventRepository userEventRepository,
            IInputOutputPortRepository inputOutputPortRepository,
            IInputOutputPortRuleRepository inputOutputPortsRuleRepository,
            IInputOutputPortLogRepository inputOutputPortsLogRepository,
            ILogger<InputOutputPortSettings> logger)
            : base(generalOptionsRepository)
        {
            UserEventRepository = userEventRepository;
            InputOutputPortRepository = inputOutputPortRepository;
            InputOutputPortsRuleRepository = inputOutputPortsRuleRepository;
            InputOutputPortsLogRepository = inputOutputPortsLogRepository;
            Logger = logger;
        }

        public IInputOutputPortRuleRepository InputOutputPortsRuleRepository { get; private set; }

        public IInputOutputPortLogRepository InputOutputPortsLogRepository { get; private set; }

        public IInputOutputPortRepository InputOutputPortRepository { get; private set; }

        public ILogger<InputOutputPortSettings> Logger { get; private set; }

        public IUserEventRepository UserEventRepository { get; private set; }
    }
}
