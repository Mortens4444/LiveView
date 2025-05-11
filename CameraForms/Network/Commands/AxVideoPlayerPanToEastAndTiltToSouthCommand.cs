using LiveView.Core.Interfaces;
using Mtf.Controls.x86;

namespace CameraForms.Network.Commands
{
    public class AxVideoPlayerPanToEastAndTiltToSouthCommand : ICommand
    {
        private readonly AxVideoPlayerWindow axVideoPlayerWindow;
        private readonly short cameraMoveValue;

        public AxVideoPlayerPanToEastAndTiltToSouthCommand(AxVideoPlayerWindow axVideoPlayerWindow, short cameraMoveValue)
        {
            this.axVideoPlayerWindow = axVideoPlayerWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            axVideoPlayerWindow.AxVideoPlayer.CameraMove(cameraMoveValue, cameraMoveValue);
        }
    }
}
