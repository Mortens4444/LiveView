using LiveView.Core.Interfaces;
using LiveView.Core.Services;

namespace LiveView.Network.Commands
{
    public class SecondsLeftFromGridCommand : ICommand
    {
        private readonly int gridId;
        private readonly string secondsLeftToShow;

        public SecondsLeftFromGridCommand(string gridId, string secondsLeftToShow)
        {
            this.gridId = Parser.ToInt32(gridId);
            this.secondsLeftToShow = secondsLeftToShow;
        }

        public void Execute()
        {
            Globals.ControlCenter.ShowGridInfo(gridId, secondsLeftToShow);
        }
    }
}
