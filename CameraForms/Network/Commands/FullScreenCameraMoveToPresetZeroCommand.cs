using CameraForms.Services;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;

namespace CameraForms.Network.Commands
{
    public class FullScreenCameraMoveToPresetZeroCommand : ICommand
    {
        private readonly FullScreenCameraMessageHandler fullScreenCameraMessageHandler;

        public FullScreenCameraMoveToPresetZeroCommand(FullScreenCameraMessageHandler fullScreenCameraMessageHandler)
        {
            this.fullScreenCameraMessageHandler = fullScreenCameraMessageHandler;
        }

        public void Execute()
        {
            UriCaller.CallUrl(fullScreenCameraMessageHandler.PtzMoveToPresetZero?.FunctionCallback);
        }
    }
}
