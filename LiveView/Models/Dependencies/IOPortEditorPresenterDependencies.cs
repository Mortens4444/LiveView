using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class IOPortEditorPresenterDependencies : BasePresenterDependencies
    {
        public IOPortEditorPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IIOPortRepository ioPortRepository,
            ILogger<IOPortEditor> logger)
            : base(generalOptionsRepository)
        {
            IOPortRepository = ioPortRepository;
            Logger = logger;
        }

        public IIOPortRepository IOPortRepository { get; private set; }

        public ILogger<IOPortEditor> Logger { get; private set; }
    }
}
