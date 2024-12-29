using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class GeneralOptionsPresenterDependencies : BasePresenterDependencies
    {
        public GeneralOptionsPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            ILogger<GeneralOptionsForm> logger)
            : base(generalOptionsRepository)
        {
            Logger = logger;
        }

        public ILogger<GeneralOptionsForm> Logger { get; private set; }
    }
}
