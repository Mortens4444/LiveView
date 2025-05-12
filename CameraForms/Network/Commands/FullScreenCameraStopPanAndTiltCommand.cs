using CameraForms.Services;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;

namespace CameraForms.Network.Commands
{
    public class FullScreenCameraStopPanAndTiltCommand : ICommand
    {
        private readonly FullScreenCameraMessageHandler fullScreenCameraMessageHandler;

        public FullScreenCameraStopPanAndTiltCommand(FullScreenCameraMessageHandler fullScreenCameraMessageHandler)
        {
            this.fullScreenCameraMessageHandler = fullScreenCameraMessageHandler;
        }

        public void Execute()
        {
            UriCaller.CallUrl(fullScreenCameraMessageHandler.PtzStop?.FunctionCallback);
        }
    }
}
