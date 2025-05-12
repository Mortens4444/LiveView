using LiveView.Core.Interfaces;
using Sequence.Services;

namespace Sequence.Network.Commands
{
    public class ChangeIsPausedStateCommand : ICommand
    {
        private readonly GridSequenceManager gridSequenceManager;

        public ChangeIsPausedStateCommand(GridSequenceManager gridSequenceManager)
        {
            this.gridSequenceManager = gridSequenceManager;
        }

        public void Execute()
        {
            gridSequenceManager.ChangeIsPausedState();
        }
    }
}
