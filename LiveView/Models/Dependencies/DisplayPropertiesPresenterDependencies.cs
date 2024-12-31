using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class DisplayPropertiesPresenterDependencies : BasePresenterDependencies
    {
        public DisplayPropertiesPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IDisplayRepository displayRepository,
            ILogger<DisplayProperties> logger)
            : base(generalOptionsRepository)
        {
            DisplayRepository = displayRepository;
            Logger = logger;
        }

        public IDisplayRepository DisplayRepository { get; private set; }

        public ILogger<DisplayProperties> Logger { get; private set; }
    }
}
