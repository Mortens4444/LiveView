using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR66;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public class SunellLegacyVideoWindowCommandFactory : BaseCommandFactory
    {
        public SunellLegacyVideoWindowCommandFactory(Form form, SunellVideoWindowLegacy sunellVideoWindowLegacy, short cameraMoveValue)
            : base(new Dictionary<string, Func<ICommand>>
            {
                { NetworkCommand.Close.ToString(), () => new CloseCommand(form) },
                { NetworkCommand.Kill.ToString(), () => new CloseCommand(form) },
                { NetworkCommand.PanToEastAndTiltToNorth.ToString(), () => new SunellLegacyVideoWindowPanToEastAndTiltToNorthCommand(sunellVideoWindowLegacy, cameraMoveValue) },
                { NetworkCommand.PanToWestAndTiltToNorth.ToString(), () => new SunellLegacyVideoWindowPanToWestAndTiltToNorthCommand(sunellVideoWindowLegacy, cameraMoveValue) },
                { NetworkCommand.MoveToPresetZero.ToString(), () => new SunellLegacyVideoWindowMoveToPresetZeroCommand(sunellVideoWindowLegacy) },
                { NetworkCommand.PanToEastAndTiltToSouth.ToString(), () => new SunellLegacyVideoWindowPanToEastAndTiltToSouthCommand(sunellVideoWindowLegacy, cameraMoveValue) },
                { NetworkCommand.PanToWestAndTiltToSouth.ToString(), () => new SunellLegacyVideoWindowPanToWestAndTiltToSouthCommand(sunellVideoWindowLegacy, cameraMoveValue) },
                { NetworkCommand.PanToEast.ToString(), () => new SunellLegacyVideoWindowPanToEastCommand(sunellVideoWindowLegacy, cameraMoveValue) },
                { NetworkCommand.PanToWest.ToString(), () => new SunellLegacyVideoWindowPanToWestCommand(sunellVideoWindowLegacy, cameraMoveValue) },
                { NetworkCommand.TiltToNorth.ToString(), () => new SunellLegacyVideoWindowTiltToNorthCommand(sunellVideoWindowLegacy) },
                { NetworkCommand.TiltToSouth.ToString(), () => new SunellLegacyVideoWindowTiltToSouthCommand(sunellVideoWindowLegacy) },
                { NetworkCommand.StopPanAndTilt.ToString(), () => new SunellLegacyVideoWindowStopPanAndTiltCommand(sunellVideoWindowLegacy) },
                { NetworkCommand.StopZoom.ToString(), () => new SunellLegacyVideoWindowStopZoomCommand(sunellVideoWindowLegacy) },
                { NetworkCommand.ZoomIn.ToString(), () => new SunellLegacyVideoWindowZoomInCommand(sunellVideoWindowLegacy) },
                { NetworkCommand.ZoomOut.ToString(), () => new SunellLegacyVideoWindowZoomOutCommand(sunellVideoWindowLegacy) }
            })
        { }
    }
}
