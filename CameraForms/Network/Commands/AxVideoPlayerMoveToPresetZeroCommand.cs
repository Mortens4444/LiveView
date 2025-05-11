using LiveView.Core.Interfaces;
using Mtf.Controls.x86;

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
