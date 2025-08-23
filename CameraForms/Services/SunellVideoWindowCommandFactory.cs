using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR67;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public static class SunellVideoWindowCommandFactory
    {
        public static ReadOnlyCollection<ICommand> Create(Form form, SunellVideoWindow sunellVideoWindow, string messages)
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
                else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowPanToEastAndTiltToNorthCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowPanToWestAndTiltToNorthCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowMoveToPresetZeroCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowPanToEastAndTiltToSouthCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowPanToWestAndTiltToSouthCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.PanToEast.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowPanToEastCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowPanToWestCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowTiltToNorthCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowTiltToSouthCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowStopPanAndTiltCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowStopZoomCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.ZoomIn.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowZoomInCommand(sunellVideoWindow));
                }
                else if (message.StartsWith(NetworkCommand.ZoomOut.ToString(), StringComparison.InvariantCulture))
                {
                    result.Add(new SunellVideoWindowZoomOutCommand(sunellVideoWindow));
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
