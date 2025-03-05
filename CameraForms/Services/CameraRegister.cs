using Database.Enums;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using System;
using System.Configuration;
using System.Diagnostics;

namespace CameraForms.Services
{
    public static class CameraRegister
    {
        public static Client RegisterAxVideoPlayer(long userId, long cameraId, DisplayDto display, EventHandler<DataArrivedEventArgs> dataArrivedEventHandler)
        {
            var liveViewServerIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                try
                {
                    var client = new Client(liveViewServerIp, serverPort);
                    client.DataArrived += dataArrivedEventHandler;
                    client.Connect();
                    var displayId = display?.Id ?? String.Empty;
#if NET481
                        client.Send($"{NetworkCommand.RegisterCamera}|{client.Socket.LocalEndPoint}|{userId}|{cameraId}|{displayId}|{Process.GetCurrentProcess().Id}|{(int)CameraMode.AxVideoPlayer}", true);
#else
                    client.Send($"{NetworkCommand.RegisterCamera}|{client.Socket.LocalEndPoint}|{userId}|{cameraId}|{displayId}|{Environment.ProcessId}|{(int)CameraMode.AxVideoPlayer}", true);
                    return client;
#endif
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", "LiveViewServer.ListenerPort cannot be parsed as an ushort.");
            }

            return null;
        }

        public static Client RegisterVideoSource(long userId, string serverIp, string videoCaptureSource, DisplayDto display, EventHandler<DataArrivedEventArgs> dataArrivedEventHandler)
        {
            var liveViewServerIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                try
                {
                    var client = new Client(liveViewServerIp, serverPort);
                    client.DataArrived += dataArrivedEventHandler;
                    client.Connect();
                    var displayId = display?.Id ?? String.Empty;
#if NET481
                    client.Send($"{NetworkCommand.RegisterVideoSource}|{client.Socket.LocalEndPoint}|{userId}|{serverIp}|{videoCaptureSource}|{displayId}|{Process.GetCurrentProcess().Id}|{(int)CameraMode.VideoSource}", true);
#else
                    client.Send($"{NetworkCommand.RegisterVideoSource}|{client.Socket.LocalEndPoint}|{userId}|{serverIp}|{videoCaptureSource}|{displayId}|{Environment.ProcessId}|{(int)CameraMode.VideoSource}", true);
#endif
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", "LiveViewServer.ListenerPort cannot be parsed as an ushort.");
            }

            return null;
        }

        public static Client RegisterCameraWithUrl(long userId, string url, DisplayDto display, EventHandler<DataArrivedEventArgs> dataArrivedEventHandler, CameraMode cameraMode)
        {
            var liveViewServerIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                try
                {
                    var client = new Client(liveViewServerIp, serverPort);
                    client.DataArrived += dataArrivedEventHandler;
                    client.Connect();
                    var displayId = display?.Id ?? String.Empty;
#if NET481
                    client.Send($"{NetworkCommand.RegisterCameraWithUrl}|{client.Socket.LocalEndPoint}|{userId}|{url}|{displayId}|{Process.GetCurrentProcess().Id}|{(int)cameraMode}", true);
#else
                    client.Send($"{NetworkCommand.RegisterCameraWithUrl}|{client.Socket.LocalEndPoint}|{userId}|{url}|{displayId}|{Environment.ProcessId}|{(int)cameraMode}", true);
#endif
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", "LiveViewServer.ListenerPort cannot be parsed as an ushort.");
            }

            return null;
        }
    }
}
