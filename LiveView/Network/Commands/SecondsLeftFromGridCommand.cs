using LiveView.Core.Interfaces;

namespace LiveView.Network.Commands
{
    public class SecondsLeftFromGridCommand : ICommand
    {
        private readonly long gridId;
        private readonly string secondsLeftToShow;

        public SecondsLeftFromGridCommand(string gridId, string secondsLeftToShow)
        {
            long.TryParse(gridId, out this.gridId);
            this.secondsLeftToShow = secondsLeftToShow;
        }

        public void Execute()
        {
            Globals.ControlCenter.ShowGridInfo(gridId, secondsLeftToShow);
        }
    }
}
