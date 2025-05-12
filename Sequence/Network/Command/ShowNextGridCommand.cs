using LiveView.Core.Interfaces;
using Sequence.Services;

namespace Sequence.Network.Commands
{
    public class ShowNextGridCommand : ICommand
    {
        private readonly GridSequenceManager gridSequenceManager;

        public ShowNextGridCommand(GridSequenceManager gridSequenceManager)
        {
            this.gridSequenceManager = gridSequenceManager;
        }

        public void Execute()
        {
            gridSequenceManager.ShowNextGrid();
        }
    }
}
