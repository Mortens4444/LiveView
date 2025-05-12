using Database.Enums;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using System;

namespace CameraForms.Services
{
    public static class CameraRegister
    {
        public static Client RegisterCamera(long userId, long cameraId, DisplayDto display, EventHandler<DataArrivedEventArgs> dataArrivedEventHandler, CameraMode cameraMode)
        {
            var liveViewServerIp = AppConfig.GetString(LiveView.Core.Constants.LiveViewServerIpAddress);
            var serverPort = AppConfig.GetUInt16WithThrowOnError(LiveView.Core.Constants.LiveViewServerListenerPort);
            if (serverPort != default)
            {
                try
                {
                    var client = ConnectWithClient(liveViewServerIp, serverPort, dataArrivedEventHandler);
                    var processDisplayInfo = new ProcessDisplayInfo(display, client);
                    client.Send($"{NetworkCommand.RegisterCamera}|{processDisplayInfo.HostInfo}|{userId}|{cameraId}|{processDisplayInfo.DisplayId}|{processDisplayInfo.ProcessId}|{(int)cameraMode}", true);
                    return client;
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", $"{LiveView.Core.Constants.LiveViewServerListenerPort} cannot be parsed as an ushort.");
            }

            return null;
        }

        public static Client RegisterVideoSource(long userId, string serverIp, string videoCaptureSource, DisplayDto display, EventHandler<DataArrivedEventArgs> dataArrivedEventHandler)
        {
            var liveViewServerIp = AppConfig.GetString(LiveView.Core.Constants.LiveViewServerIpAddress);
            var serverPort = AppConfig.GetUInt16WithThrowOnError(LiveView.Core.Constants.LiveViewServerListenerPort);
            if (serverPort != default)
            {
                try
                {
                    var client = ConnectWithClient(liveViewServerIp, serverPort, dataArrivedEventHandler);
                    var processDisplayInfo = new ProcessDisplayInfo(display, client);
                    client.Send($"{NetworkCommand.RegisterVideoSource}|{processDisplayInfo.HostInfo}|{userId}|{serverIp}|{videoCaptureSource}|{processDisplayInfo.DisplayId}|{processDisplayInfo.ProcessId}|{(int)CameraMode.VideoSource}", true);
                    return client;
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", $"{LiveView.Core.Constants.LiveViewServerListenerPort} cannot be parsed as an ushort.");
            }

            return null;
        }

        private static Client ConnectWithClient(string liveViewServerIp, ushort serverPort, EventHandler<DataArrivedEventArgs> dataArrivedEventHandler)
        {
            var client = new Client(liveViewServerIp, serverPort);
            client.DataArrived += dataArrivedEventHandler;
            client.Connect();
            return client;
        }
    }
}
