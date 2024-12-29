using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class DisplayPropertiesPresenterDependencies : BasePresenterDependencies
    {
        public DisplayPropertiesPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IDisplayRepository<Display> displayRepository,
            ILogger<DisplayProperties> logger)
            : base(generalOptionsRepository)
        {
            DisplayRepository = displayRepository;
            Logger = logger;
        }

        public IDisplayRepository<Display> DisplayRepository { get; private set; }

        public ILogger<DisplayProperties> Logger { get; private set; }
    }
}
