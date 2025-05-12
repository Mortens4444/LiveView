using CameraForms.Services;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;

namespace CameraForms.Network.Commands
{
    public class FullScreenCameraPanToWestAndTiltToNorthCommand : ICommand
    {
        private readonly FullScreenCameraMessageHandler fullScreenCameraMessageHandler;
        private readonly short cameraMoveValue;

        public FullScreenCameraPanToWestAndTiltToNorthCommand(FullScreenCameraMessageHandler fullScreenCameraMessageHandler, short cameraMoveValue = 0)
        {
            this.fullScreenCameraMessageHandler = fullScreenCameraMessageHandler;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            UriCaller.CallUrl(fullScreenCameraMessageHandler.PtzUpLeft?.FunctionCallback);
        }
    }
}
