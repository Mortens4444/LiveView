using LiveView.Core.Interfaces;
using Mtf.Controls.Video.ActiveX;

namespace CameraForms.Network.Commands
{
    public class AxVideoPlayerMoveToPresetZeroCommand : ICommand
    {
        private readonly AxVideoPlayerWindow axVideoPlayerWindow;

        public AxVideoPlayerMoveToPresetZeroCommand(AxVideoPlayerWindow axVideoPlayerWindow)
        {
            this.axVideoPlayerWindow = axVideoPlayerWindow;
        }

        public void Execute()
        {
            axVideoPlayerWindow.AxVideoPlayer.CameraGoToPreset(0);
        }
    }
}
