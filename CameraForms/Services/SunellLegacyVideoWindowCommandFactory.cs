using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Mtf.Controls.Sunell.IPR66;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public static class SunellLegacyVideoWindowCommandFactory
    {
        public static ReadOnlyCollection<ICommand> Create(Form form, SunellVideoWindowLegacy sunellVideoWindow, string messages, short cameraMoveValue)
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
                    result.Add(new SunellLegacyVideoWindowPanToEastCommand(sunellVideoWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowTiltToNorthCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowPanToEastAndTiltToNorthCommand(sunellVideoWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowPanToWestAndTiltToNorthCommand(sunellVideoWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowMoveToPresetZeroCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowTiltToSouthCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowPanToEastAndTiltToSouthCommand(sunellVideoWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowPanToWestAndTiltToSouthCommand(sunellVideoWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowPanToWestCommand(sunellVideoWindow, cameraMoveValue));
                }
                else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowStopPanAndTiltCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowStopZoomCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.ZoomIn.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowZoomInCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.ZoomOut.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellLegacyVideoWindowZoomOutCommand(sunellVideoWindow));
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
