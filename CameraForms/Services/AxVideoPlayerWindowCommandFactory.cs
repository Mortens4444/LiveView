using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Mtf.Controls.Video.ActiveX;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public class AxVideoPlayerWindowCommandFactory : BaseCommandFactory
    {
        public AxVideoPlayerWindowCommandFactory(Form form, AxVideoPlayerWindow axVideoPlayerWindow, short cameraMoveValue)
            : base(new Dictionary<string, Func<ICommand>>
            {
                { NetworkCommand.Close.ToString(), () => new CloseCommand(form) },
                { NetworkCommand.Kill.ToString(), () => new CloseCommand(form) },
                { NetworkCommand.PanToEastAndTiltToNorth.ToString(), () => new AxVideoPlayerPanToEastAndTiltToNorthCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.PanToWestAndTiltToNorth.ToString(), () => new AxVideoPlayerPanToWestAndTiltToNorthCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.MoveToPresetZero.ToString(), () => new AxVideoPlayerMoveToPresetZeroCommand(axVideoPlayerWindow) },
                { NetworkCommand.PanToEastAndTiltToSouth.ToString(), () => new AxVideoPlayerPanToEastAndTiltToSouthCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.PanToWestAndTiltToSouth.ToString(), () => new AxVideoPlayerPanToWestAndTiltToSouthCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.PanToEast.ToString(), () => new AxVideoPlayerPanToEastCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.PanToWest.ToString(), () => new AxVideoPlayerPanToWestCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.TiltToNorth.ToString(), () => new AxVideoPlayerTiltToNorthCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.TiltToSouth.ToString(), () => new AxVideoPlayerTiltToSouthCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.StopPanAndTilt.ToString(), () => new AxVideoPlayerStopPanAndTiltCommand(axVideoPlayerWindow) },
                { NetworkCommand.StopZoom.ToString(), () => new AxVideoPlayerStopZoomCommand(axVideoPlayerWindow) },
                { NetworkCommand.ZoomIn.ToString(), () => new AxVideoPlayerZoomInCommand(axVideoPlayerWindow, cameraMoveValue) },
                { NetworkCommand.ZoomOut.ToString(), () => new AxVideoPlayerZoomOutCommand(axVideoPlayerWindow, cameraMoveValue) }
            }) { }
    }
}
