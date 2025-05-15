using LiveView.Core.Interfaces;
using LiveView.Core.Services;

namespace LiveView.Network.Commands
{
    public class SecondsLeftFromGridCommand : ICommand
    {
        private readonly long gridId;
        private readonly string secondsLeftToShow;

        public SecondsLeftFromGridCommand(string gridId, string secondsLeftToShow)
        {
            this.gridId = Parser.ToInt64(gridId);
            this.secondsLeftToShow = secondsLeftToShow;
        }

        public void Execute()
        {
            Globals.ControlCenter.ShowGridInfo(gridId, secondsLeftToShow);
        }
    }
}
