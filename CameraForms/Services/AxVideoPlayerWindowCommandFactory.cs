using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Mtf.Controls.Video.ActiveX;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public static class AxVideoPlayerWindowCommandFactory
    {
        public static List<ICommand> Create(Form form, AxVideoPlayerWindow axVideoPlayerWindow, string messages, short cameraMoveValue)
        {
            var result = new List<ICommand>();
            var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var message in allMessages)
            {
                var messageParts = message.Split('|');

                if (message.StartsWith(NetworkCommand.Close.ToString(), StringComparison.InvariantCulture) ||
                    (message.StartsWith(NetworkCommand.Kill.ToString(), StringComparison.InvariantCulture)))
                {
                    result.Add(new CloseCommand(form));
                }
                else if (message.StartsWith(NetworkCommand.PanToEast.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerPanToEastCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerTiltToNorthCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerPanToEastAndTiltToNorthCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerPanToWestAndTiltToNorthCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerMoveToPresetZeroCommand(axVideoPlayerWindow));
                }
                else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerTiltToSouthCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerPanToEastAndTiltToSouthCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerPanToWestAndTiltToSouthCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerPanToWestCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerStopPanAndTiltCommand(axVideoPlayerWindow));
                }
                else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerStopZoomCommand(axVideoPlayerWindow));
                }
                else if (message.StartsWith(NetworkCommand.ZoomIn.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerZoomInCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.ZoomOut.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new AxVideoPlayerZoomOutCommand(axVideoPlayerWindow, cameraMoveValue));
                }
                else
                {
                    result.Add(new ShowErrorCommand(message));
                }
            }
            return result;
        }
    }
}
