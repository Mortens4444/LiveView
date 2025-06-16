using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public static class FullScreenCameraCommandFactory
    {
        public static ReadOnlyCollection<ICommand> Create(FullScreenCameraMessageHandler fullScreenCameraMessageHandler, Form form, string messages)
        {
            var result = new List<ICommand>();
            if (String.IsNullOrEmpty(messages))
            {
                return new ReadOnlyCollection<ICommand>(result);
            }

            var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var message in allMessages)
            {
                //var messageParts = message.Split('|');
                if (message.StartsWith(NetworkCommand.Close.ToString(), StringComparison.InvariantCulture) ||
                    (message.StartsWith(NetworkCommand.Kill.ToString(), StringComparison.InvariantCulture)))
                {
                    result.Add(new CloseCommand(form));
                }
                else if (message.StartsWith(NetworkCommand.PanToEast.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraPanToEastCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraTiltToNorthCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraPanToEastAndTiltToNorthCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraPanToWestAndTiltToNorthCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraMoveToPresetZeroCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraTiltToSouthCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraPanToEastAndTiltToSouthCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraPanToWestAndTiltToSouthCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraPanToWestCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraStopPanAndTiltCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraStopZoomCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.ZoomIn.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraZoomInCommand(fullScreenCameraMessageHandler));
                }
                else if (message.StartsWith(NetworkCommand.ZoomOut.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new FullScreenCameraZoomOutCommand(fullScreenCameraMessageHandler));
                }
                else
                {
                    result.Add(new ShowErrorCommand(message));
                }
            }

            return new ReadOnlyCollection<ICommand>(result);
        }
    }
}
