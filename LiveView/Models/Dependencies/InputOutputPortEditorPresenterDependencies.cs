using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class InputOutputPortEditorPresenterDependencies : BasePresenterDependencies
    {
        public InputOutputPortEditorPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IInputOutputPortRepository inputOutputPortRepository,
            ILogger<InputOutputPortEditor> logger)
            : base(generalOptionsRepository)
        {
            InputOutputPortRepository = inputOutputPortRepository;
            Logger = logger;
        }

        public IInputOutputPortRepository InputOutputPortRepository { get; private set; }

        public ILogger<InputOutputPortEditor> Logger { get; private set; }
    }
}
