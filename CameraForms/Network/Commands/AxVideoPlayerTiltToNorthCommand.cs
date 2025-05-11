using LiveView.Core.Interfaces;
using Mtf.Controls.x86;

namespace CameraForms.Network.Commands
{
    public class AxVideoPlayerTiltToNorthCommand : ICommand
    {
        private readonly AxVideoPlayerWindow axVideoPlayerWindow;
        private readonly short cameraMoveValue;

        public AxVideoPlayerTiltToNorthCommand(AxVideoPlayerWindow axVideoPlayerWindow, short cameraMoveValue)
        {
            this.axVideoPlayerWindow = axVideoPlayerWindow;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            axVideoPlayerWindow.AxVideoPlayer.CameraMove((short)-cameraMoveValue, 0);
        }
    }
}
