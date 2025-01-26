using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class KBD300ASimulatorPresenterDependencies : BasePresenterDependencies
    {
        public KBD300ASimulatorPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ILogger<KBD300ASimulator> logger)
            : base(generalOptionsRepository)
        {
            Logger = logger;
        }

        public ILogger<KBD300ASimulator> Logger { get; private set; }
    }
}
