using LiveView.Core.Interfaces;
using Mtf.Controls.Video.ActiveX;

namespace CameraForms.Network.Commands
{
    public class AxVideoPlayerStopPanAndTiltCommand : ICommand
    {
        private readonly AxVideoPlayerWindow axVideoPlayerWindow;

        public AxVideoPlayerStopPanAndTiltCommand(AxVideoPlayerWindow axVideoPlayerWindow)
        {
            this.axVideoPlayerWindow = axVideoPlayerWindow;
        }

        public void Execute()
        {
            axVideoPlayerWindow.AxVideoPlayer.CameraMove(0, 0);
        }
    }
}
