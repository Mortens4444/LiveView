using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR66;

namespace CameraForms.Network.Commands
{
    public class SunellLegacyVideoWindowPanToEastCommand : ICommand
    {
        private readonly SunellVideoWindowLegacy sunellVideoWindow;
        private readonly short cameraMoveValue;

        public SunellLegacyVideoWindowPanToEastCommand(SunellVideoWindowLegacy sunellVideoWindow, short cameraMoveValue)
        {
            this.sunellVideoWindow = sunellVideoWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            sunellVideoWindow.PTZ_RotateRight(cameraMoveValue);
        }
    }
}
