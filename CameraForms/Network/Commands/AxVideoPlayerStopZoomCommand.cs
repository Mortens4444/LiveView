using LiveView.Core.Interfaces;
using Mtf.Controls.x86;

namespace CameraForms.Network.Commands
{
    public class AxVideoPlayerStopZoomCommand : ICommand
    {
        private readonly AxVideoPlayerWindow axVideoPlayerWindow;

        public AxVideoPlayerStopZoomCommand(AxVideoPlayerWindow axVideoPlayerWindow)
        {
            this.axVideoPlayerWindow = axVideoPlayerWindow;
        }

        public void Execute()
        {
            axVideoPlayerWindow.AxVideoPlayer.CameraZoom(0);
        }
    }
}
