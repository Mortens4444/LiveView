using Database.Enums;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Network.Extensions;
using System;
using System.Configuration;

namespace CameraForms.Services
{
    public static class CameraRegister
    {
        public static Client RegisterCamera(long userId, long cameraId, DisplayDto display, EventHandler<DataArrivedEventArgs> dataArrivedEventHandler, CameraMode cameraMode)
        {
            var liveViewServerIp = ConfigurationManager.AppSettings[LiveView.Core.Constants.LiveViewServerIpAddress];
            var listenerPort = ConfigurationManager.AppSettings[LiveView.Core.Constants.LiveViewServerListenerPort];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                try
                {
                    var client = new Client(liveViewServerIp, serverPort);
                    client.DataArrived += dataArrivedEventHandler;
                    client.Connect();
                    var displayId = display?.Id ?? String.Empty;
                    var hostInfo = client.Socket?.LocalEndPoint?.GetEndPointInfo();
                    var processId = ProcessUtils.GetProcessId();
                    client.Send($"{NetworkCommand.RegisterCamera}|{hostInfo}|{userId}|{cameraId}|{displayId}|{processId}|{(int)cameraMode}", true);
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
            var liveViewServerIp = ConfigurationManager.AppSettings[LiveView.Core.Constants.LiveViewServerIpAddress];
            var listenerPort = ConfigurationManager.AppSettings[LiveView.Core.Constants.LiveViewServerListenerPort];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                try
                {
                    var client = new Client(liveViewServerIp, serverPort);
                    client.DataArrived += dataArrivedEventHandler;
                    client.Connect();
                    var displayId = display?.Id ?? String.Empty;
                    var hostInfo = client.Socket?.LocalEndPoint?.GetEndPointInfo();
                    var processId = ProcessUtils.GetProcessId();
                    client.Send($"{NetworkCommand.RegisterVideoSource}|{hostInfo}|{userId}|{serverIp}|{videoCaptureSource}|{displayId}|{processId}|{(int)CameraMode.VideoSource}", true);
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
    }
}
