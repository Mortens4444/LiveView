using LiveView.Core.Interfaces;
using Sequence.Services;

namespace Sequence.Network.Commands
{
    public class RearrangeGridsCommand : ICommand
    {
        private readonly GridSequenceManager gridSequenceManager;

        public RearrangeGridsCommand(GridSequenceManager gridSequenceManager)
        {
            this.gridSequenceManager = gridSequenceManager;
        }

        public void Execute()
        {
            //gridSequenceManager.RearrangeGrids();
        }
    }
}
