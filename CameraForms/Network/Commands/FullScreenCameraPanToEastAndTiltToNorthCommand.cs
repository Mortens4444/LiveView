using CameraForms.Services;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;

namespace CameraForms.Network.Commands
{
    public class FullScreenCameraPanToEastAndTiltToNorthCommand : ICommand
    {
        private readonly FullScreenCameraMessageHandler fullScreenCameraMessageHandler;
        private readonly short cameraMoveValue;

        public FullScreenCameraPanToEastAndTiltToNorthCommand(FullScreenCameraMessageHandler fullScreenCameraMessageHandler, short cameraMoveValue = 0)
        {
            this.fullScreenCameraMessageHandler = fullScreenCameraMessageHandler;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            UriCaller.CallUrl(fullScreenCameraMessageHandler.PtzUpRight?.FunctionCallback);
        }
    }
}
