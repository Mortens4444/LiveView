using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

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

        public void AddGrid()
        {
            throw new NotImplementedException();
        }

        public void AddOrMUpdateSequence()
        {
            throw new NotImplementedException();
        }

        public void DeleteGrid()
        {
            throw new NotImplementedException();
        }

        public void DeleteSequence()
        {
            throw new NotImplementedException();
        }

        public void MoveGridDown()
        {
            throw new NotImplementedException();
        }

        public void MoveGridUp()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
