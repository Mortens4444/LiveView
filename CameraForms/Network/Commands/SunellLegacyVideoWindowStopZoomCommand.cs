using LiveView.Core.Interfaces;
using Mtf.Controls.Sunell.IPR66;

namespace CameraForms.Network.Commands
{
    public class SunellLegacyVideoWindowStopZoomCommand : ICommand
    {
        private readonly SunellVideoWindowLegacy sunellVideoWindow;

        public SunellLegacyVideoWindowStopZoomCommand(SunellVideoWindowLegacy sunellVideoWindow)
        {
            this.sunellVideoWindow = sunellVideoWindow;
        }

        public void Execute()
        {
            sunellVideoWindow.PTZ_Stop();
        }
    }
}
