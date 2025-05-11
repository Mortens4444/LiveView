using LiveView.Core.Interfaces;
using Mtf.Controls.Sunell.IPR67;

namespace CameraForms.Network.Commands
{
    public class SunellVideoWindowMoveToPresetZeroCommand : ICommand
    {
        private readonly SunellVideoWindow sunellVideoWindow;

        public SunellVideoWindowMoveToPresetZeroCommand(SunellVideoWindow sunellVideoWindow)
        {
            this.sunellVideoWindow = sunellVideoWindow;
        }

        public void Execute()
        {
        }
    }
}
