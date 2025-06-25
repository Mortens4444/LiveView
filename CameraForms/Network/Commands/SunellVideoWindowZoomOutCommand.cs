using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR67;
using Mtf.Controls.Video.Sunell.IPR67.Enums;

namespace CameraForms.Network.Commands
{
    public class SunellVideoWindowZoomOutCommand : ICommand
    {
        private readonly SunellVideoWindow sunellVideoWindow;
        private readonly short cameraMoveValue;

        public SunellVideoWindowZoomOutCommand(SunellVideoWindow sunellVideoWindow, short cameraMoveValue = 0)
        {
            this.sunellVideoWindow = sunellVideoWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            sunellVideoWindow.PtzZoom(PtzZoomOperation.Out);
        }
    }
}
