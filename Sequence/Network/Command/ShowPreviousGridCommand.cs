using LiveView.Core.Interfaces;
using Sequence.Services;

namespace Sequence.Network.Commands
{
    public class ShowPreviousGridCommand : ICommand
    {
        private readonly GridSequenceManager gridSequenceManager;

        public ShowPreviousGridCommand(GridSequenceManager gridSequenceManager)
        {
            this.gridSequenceManager = gridSequenceManager;
        }

        public void Execute()
        {
            gridSequenceManager.ShowPreviousGrid();
        }
    }
}
