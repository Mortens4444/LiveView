using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR66;

namespace CameraForms.Network.Commands
{
    public class SunellLegacyVideoWindowTiltToSouthCommand : ICommand
    {
        private readonly SunellVideoWindowLegacy sunellVideoWindow;
        private readonly short cameraMoveValue;

        public SunellLegacyVideoWindowTiltToSouthCommand(SunellVideoWindowLegacy sunellVideoWindow, short cameraMoveValue = 0)
        {
            this.sunellVideoWindow = sunellVideoWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            sunellVideoWindow.PTZ_RotateDown(cameraMoveValue);
        }
    }
}
