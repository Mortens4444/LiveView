using Database.Enums;
using LiveView.Core.Dto;
using Mtf.Network;
using Mtf.Network.EventArg;
using System;

namespace CameraForms.Interfaces
{
    public interface ICameraRegister
    {
        Client RegisterCamera(long userId, long cameraId, DisplayDto display, EventHandler<DataArrivedEventArgs> handler, CameraMode mode);

        Client RegisterVideoSource(long userId, string serverIp, string source, DisplayDto display, EventHandler<DataArrivedEventArgs> handler);
    }
}
