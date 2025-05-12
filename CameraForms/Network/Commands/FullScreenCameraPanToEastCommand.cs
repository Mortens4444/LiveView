using CameraForms.Services;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;

namespace CameraForms.Network.Commands
{
    public class FullScreenCameraPanToEastCommand : ICommand
    {
        private readonly FullScreenCameraMessageHandler fullScreenCameraMessageHandler;
        private readonly short cameraMoveValue;

        public FullScreenCameraPanToEastCommand(FullScreenCameraMessageHandler fullScreenCameraMessageHandler, short cameraMoveValue = 0)
        {
            this.fullScreenCameraMessageHandler = fullScreenCameraMessageHandler;
            this.cameraMoveValue = cameraMoveValue;
        }

        public void Execute()
        {
            UriCaller.CallUrl(fullScreenCameraMessageHandler.PtzRight?.FunctionCallback);
        }
    }
}
