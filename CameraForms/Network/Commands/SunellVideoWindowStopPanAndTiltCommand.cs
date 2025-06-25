using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR67;
using Mtf.Controls.Video.Sunell.IPR67.Enums;

namespace CameraForms.Network.Commands
{
    public class SunellVideoWindowStopPanAndTiltCommand : ICommand
    {
        private readonly SunellVideoWindow sunellVideoWindow;

        public SunellVideoWindowStopPanAndTiltCommand(SunellVideoWindow sunellVideoWindow)
        {
            this.sunellVideoWindow = sunellVideoWindow;
        }

        public void Execute()
        {
            sunellVideoWindow.PtzRotate(PtzRotateOperation.Stop);
        }
    }
}
