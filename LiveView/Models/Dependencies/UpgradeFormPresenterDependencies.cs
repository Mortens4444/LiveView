using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class UpgradeFormPresenterDependencies : BasePresenterDependencies
    {
        public UpgradeFormPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ILogger<UpgradeForm> logger)
            : base(generalOptionsRepository)
        {
            Logger = logger;
        }

        public ILogger<UpgradeForm> Logger { get; private set; }
    }
}
