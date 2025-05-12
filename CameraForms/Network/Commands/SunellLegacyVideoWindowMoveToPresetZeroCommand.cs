using LiveView.Core.Interfaces;
using Mtf.Controls.Sunell.IPR66;

namespace CameraForms.Network.Commands
{
    public class SunellLegacyVideoWindowMoveToPresetZeroCommand : ICommand
    {
        private readonly SunellVideoWindowLegacy sunellVideoWindow;

        public SunellLegacyVideoWindowMoveToPresetZeroCommand(SunellVideoWindowLegacy sunellVideoWindow)
        {
            this.sunellVideoWindow = sunellVideoWindow;
        }

        public void Execute()
        {
        }
    }
}
