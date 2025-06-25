using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR66;

namespace CameraForms.Network.Commands
{
    public class SunellLegacyVideoWindowStopPanAndTiltCommand : ICommand
    {
        private readonly SunellVideoWindowLegacy sunellVideoWindow;

        public SunellLegacyVideoWindowStopPanAndTiltCommand(SunellVideoWindowLegacy sunellVideoWindow)
        {
            this.sunellVideoWindow = sunellVideoWindow;
        }

        public void Execute()
        {
            sunellVideoWindow.PTZ_Stop();
        }
    }
}
