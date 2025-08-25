using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Mtf.Controls.Video.Sunell.IPR66;
using Mtf.Controls.Video.Sunell.IPR67;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public class SunellVideoWindowCommandFactory : BaseCommandFactory
    {
        public SunellVideoWindowCommandFactory(Form form, SunellVideoWindow sunellVideoWindow)
            : base(new Dictionary<string, Func<ICommand>>
            {
                { NetworkCommand.Close.ToString(), () => new CloseCommand(form) },
                { NetworkCommand.Kill.ToString(), () => new CloseCommand(form) },
                { NetworkCommand.PanToEastAndTiltToNorth.ToString(), () => new SunellVideoWindowPanToEastAndTiltToNorthCommand(sunellVideoWindow) },
                { NetworkCommand.PanToWestAndTiltToNorth.ToString(), () => new SunellVideoWindowPanToWestAndTiltToNorthCommand(sunellVideoWindow) },
                { NetworkCommand.MoveToPresetZero.ToString(), () => new SunellVideoWindowMoveToPresetZeroCommand(sunellVideoWindow) },
                { NetworkCommand.PanToEastAndTiltToSouth.ToString(), () => new SunellVideoWindowPanToEastAndTiltToSouthCommand(sunellVideoWindow) },
                { NetworkCommand.PanToWestAndTiltToSouth.ToString(), () => new SunellVideoWindowPanToWestAndTiltToSouthCommand(sunellVideoWindow) },
                { NetworkCommand.PanToEast.ToString(), () => new SunellVideoWindowPanToEastCommand(sunellVideoWindow) },
                { NetworkCommand.PanToWest.ToString(), () => new SunellVideoWindowPanToWestCommand(sunellVideoWindow) },
                { NetworkCommand.TiltToNorth.ToString(), () => new SunellVideoWindowTiltToNorthCommand(sunellVideoWindow) },
                { NetworkCommand.TiltToSouth.ToString(), () => new SunellVideoWindowTiltToSouthCommand(sunellVideoWindow) },
                { NetworkCommand.StopPanAndTilt.ToString(), () => new SunellVideoWindowStopPanAndTiltCommand(sunellVideoWindow) },
                { NetworkCommand.StopZoom.ToString(), () => new SunellVideoWindowStopZoomCommand(sunellVideoWindow) },
                { NetworkCommand.ZoomIn.ToString(), () => new SunellVideoWindowZoomInCommand(sunellVideoWindow) },
                { NetworkCommand.ZoomOut.ToString(), () => new SunellVideoWindowZoomOutCommand(sunellVideoWindow) }
            })
        { }
    }
}
