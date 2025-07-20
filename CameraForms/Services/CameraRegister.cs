using Database.Enums;
using Database.Services;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using System;

namespace CameraForms.Services
{
    public static class CameraRegister
    {
        public static Client RegisterCamera(long userId, long cameraId, DisplayDto display, EventHandler<DataArrivedEventArgs> handler, CameraMode mode)
        {
            var message = $"{NetworkCommand.RegisterCamera}|{{0}}|{userId}|{cameraId}|{{1}}|{{2}}|{(int)mode}";
            return Register(display, handler, message);
        }

        public static Client RegisterVideoSource(long userId, string serverIp, string source, DisplayDto display, EventHandler<DataArrivedEventArgs> handler)
        {
            var message = $"{NetworkCommand.RegisterVideoSource}|{{0}}|{userId}|{serverIp}|{source}|{{1}}|{{2}}|{(int)CameraMode.VideoSource}";
            return Register(display, handler, message);
        }

        private static Client Register(DisplayDto display, EventHandler<DataArrivedEventArgs> handler, string messageTemplate)
        {
            var ip = AppConfig.GetString(Database.Constants.LiveViewServerIpAddress);
            var port = AppConfig.GetUInt16WithThrowOnError(Database.Constants.LiveViewServerListenerPort);

            if (port == default)
            {
                ErrorBox.Show("General error", $"{Database.Constants.LiveViewServerListenerPort} cannot be parsed as an ushort.");
                return null;
            }

            try
            {
                var client = new Client(ip, port);
                client.DataArrived += handler;
                client.Connect();

                var info = new ProcessDisplayInfo(display, client);
                var message = String.Format(messageTemplate, info.HostInfo, info.DisplayId, info.ProcessId);
                client.Send(message, true);

                return client;
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
                return null;
            }
        }
    }
}
