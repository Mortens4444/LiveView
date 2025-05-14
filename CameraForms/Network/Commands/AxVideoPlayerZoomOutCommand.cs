using LiveView.Core.Interfaces;
using Mtf.Controls.Video.ActiveX;

namespace CameraForms.Network.Commands
{
    public class AxVideoPlayerZoomOutCommand : ICommand
    {
        private readonly AxVideoPlayerWindow axVideoPlayerWindow;
        private readonly short cameraMoveValue;

        public AxVideoPlayerZoomOutCommand(AxVideoPlayerWindow axVideoPlayerWindow, short cameraMoveValue)
        {
            this.axVideoPlayerWindow = axVideoPlayerWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            axVideoPlayerWindow.AxVideoPlayer.CameraZoom((short)-cameraMoveValue);
        }
    }
}
