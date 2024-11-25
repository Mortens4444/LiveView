using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class SequentialChainsPresenter : BasePresenter
    {
        private readonly ISequentialChainsView sequentialChainsView;
        private readonly ISequenceRepository<Sequence> sequenceRepository;
        private readonly ILogger<SequentialChains> logger;

        public SequentialChainsPresenter(ISequentialChainsView sequentialChainsView, ISequenceRepository<Sequence> sequenceRepository, ILogger<SequentialChains> logger)
            : base(sequentialChainsView)
        {
            this.sequentialChainsView = sequentialChainsView;
            this.sequenceRepository = sequenceRepository;
            this.logger = logger;
        }
    }
}
