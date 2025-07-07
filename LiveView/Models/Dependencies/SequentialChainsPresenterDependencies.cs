using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class SequentialChainsPresenterDependencies : BasePresenterDependencies
    {
        public SequentialChainsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IGridRepository gridRepository,
            ISequenceGridsRepository sequenceGridsRepository,
            ISequenceRepository sequenceRepository,
            ILogger<SequentialChains> logger)
            : base(generalOptionsRepository)
        {
            GridRepository = gridRepository;
            SequenceRepository = sequenceRepository;
            SequenceGridsRepository = sequenceGridsRepository;
            Logger = logger;
        }

        public IGridRepository GridRepository { get; private set; }

        public ISequenceRepository SequenceRepository { get; private set; }

        public ISequenceGridsRepository SequenceGridsRepository { get; private set; }

        public ILogger<SequentialChains> Logger { get; private set; }
    }
}
