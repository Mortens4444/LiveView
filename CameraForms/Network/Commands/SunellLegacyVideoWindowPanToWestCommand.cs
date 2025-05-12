using LiveView.Core.Interfaces;
using Mtf.Controls.Sunell.IPR66;

namespace CameraForms.Network.Commands
{
    public class SunellLegacyVideoWindowPanToWestCommand : ICommand
    {
        private readonly SunellVideoWindowLegacy sunellVideoWindow;
        private readonly short cameraMoveValue;

        public SunellLegacyVideoWindowPanToWestCommand(SunellVideoWindowLegacy sunellVideoWindow, short cameraMoveValue)
        {
            this.sunellVideoWindow = sunellVideoWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            sunellVideoWindow.PTZ_RotateLeft(cameraMoveValue);
        }
    }
}
