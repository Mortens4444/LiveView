using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR67;
using Mtf.Controls.Video.Sunell.IPR67.Enums;

namespace CameraForms.Network.Commands
{
    public class SunellVideoWindowPanToEastAndTiltToNorthCommand : ICommand
    {
        private readonly SunellVideoWindow sunellVideoWindow;
        private readonly short cameraMoveValue;

        public SunellVideoWindowPanToEastAndTiltToNorthCommand(SunellVideoWindow sunellVideoWindow, short cameraMoveValue = 0)
        {
            this.sunellVideoWindow = sunellVideoWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            sunellVideoWindow.PtzRotate(PtzRotateOperation.Right);
            sunellVideoWindow.PtzRotate(PtzRotateOperation.Up);
        }
    }
}
