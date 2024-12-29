using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class SequentialChainsPresenterDependencies : BasePresenterDependencies
    {
        public SequentialChainsPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IGridRepository<Grid> gridRepository,
            IGridInSequenceRepository<GridInSequence> gridInSequenceRepository,
            ISequenceRepository<Sequence> sequenceRepository,
            ILogger<SequentialChains> logger)
            : base(generalOptionsRepository)
        {
            GridRepository = gridRepository;
            SequenceRepository = sequenceRepository;
            GridInSequenceRepository = gridInSequenceRepository;
            Logger = logger;
        }

        public IGridRepository<Grid> GridRepository { get; private set; }

        public ISequenceRepository<Sequence> SequenceRepository { get; private set; }

        public IGridInSequenceRepository<GridInSequence> GridInSequenceRepository { get; private set; }

        public ILogger<SequentialChains> Logger { get; private set; }
    }
}
