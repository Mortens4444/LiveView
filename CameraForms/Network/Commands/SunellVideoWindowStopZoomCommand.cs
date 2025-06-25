using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR67;
using Mtf.Controls.Video.Sunell.IPR67.Enums;

namespace CameraForms.Network.Commands
{
    public class SunellVideoWindowStopZoomCommand : ICommand
    {
        private readonly SunellVideoWindow sunellVideoWindow;

        public SunellVideoWindowStopZoomCommand(SunellVideoWindow sunellVideoWindow)
        {
            this.sunellVideoWindow = sunellVideoWindow;
        }

        public void Execute()
        {
            sunellVideoWindow.PtzZoom(PtzZoomOperation.Stop);
        }
    }
}
