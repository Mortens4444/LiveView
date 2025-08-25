using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public class FullScreenCameraCommandFactory : BaseCommandFactory
    {
        public FullScreenCameraCommandFactory(Form form, FullScreenCameraMessageHandler fullScreenCameraMessageHandler)
            : base(new Dictionary<string, Func<ICommand>>
            {
                { NetworkCommand.Close.ToString(), () => new CloseCommand(form) },
                { NetworkCommand.Kill.ToString(), () => new CloseCommand(form) },
                { NetworkCommand.PanToEastAndTiltToNorth.ToString(), () => new FullScreenCameraPanToEastAndTiltToNorthCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.PanToWestAndTiltToNorth.ToString(), () => new FullScreenCameraPanToWestAndTiltToNorthCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.MoveToPresetZero.ToString(), () => new FullScreenCameraMoveToPresetZeroCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.PanToEastAndTiltToSouth.ToString(), () => new FullScreenCameraPanToEastAndTiltToSouthCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.PanToWestAndTiltToSouth.ToString(), () => new FullScreenCameraPanToWestAndTiltToSouthCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.PanToEast.ToString(), () => new FullScreenCameraPanToEastCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.PanToWest.ToString(), () => new FullScreenCameraPanToWestCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.TiltToNorth.ToString(), () => new FullScreenCameraTiltToNorthCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.TiltToSouth.ToString(), () => new FullScreenCameraTiltToSouthCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.StopPanAndTilt.ToString(), () => new FullScreenCameraStopPanAndTiltCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.StopZoom.ToString(), () => new FullScreenCameraStopZoomCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.ZoomIn.ToString(), () => new FullScreenCameraZoomInCommand(fullScreenCameraMessageHandler) },
                { NetworkCommand.ZoomOut.ToString(), () => new FullScreenCameraZoomOutCommand(fullScreenCameraMessageHandler) }
            })
        { }
    }
}
