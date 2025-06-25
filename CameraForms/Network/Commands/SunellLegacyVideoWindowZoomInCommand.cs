using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR66;

namespace CameraForms.Network.Commands
{
    public class SunellLegacyVideoWindowZoomInCommand : ICommand
    {
        private readonly SunellVideoWindowLegacy sunellVideoWindow;
        private readonly short cameraMoveValue;

        public SunellLegacyVideoWindowZoomInCommand(SunellVideoWindowLegacy sunellVideoWindow, short cameraMoveValue = 0)
        {
            this.sunellVideoWindow = sunellVideoWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
        }
    }
}
