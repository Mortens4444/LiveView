using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LiveView.Agent
{
    public class LiveViewConnector
    {
        private const string PressCtrlCToExit = "Press Ctrl+C to exit.";
        
        private readonly Dictionary<long, Process> cameraProcesses = new Dictionary<long, Process>();
        private readonly Dictionary<long, Process> sequenceProcesses = new Dictionary<long, Process>();
        private readonly Dictionary<string, VideoCapture> videoCaptures = new Dictionary<string, VideoCapture>();
        private readonly Dictionary<string, Server> cameraServers = new Dictionary<string, Server>(); // cameraServers and videoCaptures should be in the same dictionary
        private readonly Dictionary<string, CancellationTokenSource> cancellationTokenSources = new Dictionary<string, CancellationTokenSource>();

        private ILogger<LiveViewConnector> logger;

        private Client client;

        public LiveViewConnector(ILogger<LiveViewConnector> logger)
        {
            this.logger = logger;
        }

        public async Task ConnectAsync(string serverIp, ushort serverPort)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Attempt to connect {serverIp}:{serverPort}.");
                    client = new Client(serverIp, serverPort);
                    client.DataArrived += ClientDataArrivedEventHandler;
                    client.Connect();
                    if (client.Send($"{NetworkCommand.RegisterAgent}|{client.Socket.LocalEndPoint}|{Dns.GetHostName()}", true))
                    {
                        var displayManager = new DisplayManager();
                        var displays = displayManager.GetAll();
                        foreach (var display in displays)
                        {
                            display.Host = client.Socket.LocalEndPoint.ToString();
                            Console.WriteLine($"Registering display {display}.");
                            client.Send($"{NetworkCommand.RegisterDisplay}|{display.Serialize()}", true);
                        }

                        SendVideoCaptureSourcesToLiveView();
                        Console.WriteLine($"Connected to server {serverIp}:{serverPort}.");
                        Console.WriteLine(PressCtrlCToExit);

                        while (true)
                        {
                            Thread.Sleep(1000);
                            if (!client.Send($"{NetworkCommand.Ping}|{client.Socket.LocalEndPoint}", true))
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
#if NET462
                    logger.LogError($"Agent connection failed: {ex}");
#else
                    logger.LogError(ex, "Agent connection failed.");
#endif

                    Console.Error.WriteLine($"Connection failed: {ex}");
                    Thread.Sleep(5000);
                }
            }
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client.Encoding.GetString(e.Data)}";
                var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var message in allMessages)
                {
                    var messageParts = message.Split('|');

                    if (message.StartsWith($"{Core.Constants.CameraAppExe}|", StringComparison.InvariantCulture))
                    {
                        Console.WriteLine($"Starting process {Core.Constants.CameraAppExe} ({message}).");
                        var cameraProcessId = StartProcess(messageParts, cameraProcesses);
                        client.Send($"{NetworkCommand.SendCameraProcessId}|{cameraProcessId}", true);
                    }
                    else if (message.StartsWith($"{Core.Constants.SequenceExe}|", StringComparison.InvariantCulture))
                    {
                        Console.WriteLine($"Starting process {Core.Constants.SequenceExe} ({message}).");
                        StartProcess(messageParts, sequenceProcesses);
                    }
                    else if (message.StartsWith($"{NetworkCommand.Kill}|", StringComparison.InvariantCulture))
                    {
                        Console.WriteLine($"Killing process {messageParts[1]} ({message}).");
                        long id = Convert.ToInt64(messageParts[2], CultureInfo.InvariantCulture);
                        switch (messageParts[1])
                        {
                            case Core.Constants.CameraAppExe:
                                ProcessUtils.Kill(cameraProcesses[id]);
                                cameraProcesses.Remove(id);
                                break;
                            case Core.Constants.SequenceExe:
                                ProcessUtils.Kill(sequenceProcesses[id]);
                                sequenceProcesses.Remove(id);
                                break;
                        }
                    }
                    else if (message.StartsWith($"{NetworkCommand.KillAll}|", StringComparison.InvariantCulture))
                    {
                        Console.WriteLine($"Killing all processes of {messageParts[1]} ({message}).");
                        var processes = messageParts[1] == Core.Constants.CameraAppExe ? cameraProcesses.Values : sequenceProcesses.Values;
                        ProcessUtils.Kill(processes);
                    }
                    else if (message.StartsWith($"{NetworkCommand.VideoCaptureSourcesRequest}|", StringComparison.InvariantCulture))
                    {
                        SendVideoCaptureSourcesToLiveView();
                    }
                    else if (message.StartsWith($"{NetworkCommand.StopVideoCapture}|", StringComparison.InvariantCulture))
                    {
                        if (cancellationTokenSources.TryGetValue(messageParts[1], out var value))
                        {
                            value.Cancel();
                            cancellationTokenSources.Remove(messageParts[1]);
                        }
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToEast}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Pan = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.TiltToNorth}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Tilt = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToEastAndTiltToNorth}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Pan = value;
                        videoCaptures[videoCaptureId].Tilt = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToWestAndTiltToNorth}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Pan = value;
                        videoCaptures[videoCaptureId].Tilt = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.MoveToPresetZero}|", StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith($"{NetworkCommand.TiltToSouth}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Tilt = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToEastAndTiltToSouth}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Pan = value;
                        videoCaptures[videoCaptureId].Tilt = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToWestAndTiltToSouth}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Pan = value;
                        videoCaptures[videoCaptureId].Tilt = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToWest}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Pan = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.StopPanAndTilt}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        videoCaptures[videoCaptureId].Pan = 0;
                        videoCaptures[videoCaptureId].Tilt = 0;
                    }
                    else if (message.StartsWith($"{NetworkCommand.StopZoom}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        videoCaptures[videoCaptureId].Zoom = 0;
                    }
                    else if (message.StartsWith($"{NetworkCommand.ZoomIn}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Zoom = value;
                    }
                    else if (message.StartsWith($"{NetworkCommand.ZoomOut}|", StringComparison.InvariantCulture))
                    {
                        var videoCaptureId = messageParts[1];
                        var value = Convert.ToDouble(messageParts[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                        videoCaptures[videoCaptureId].Zoom = value;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = $"Message parse or execution failed in agent: {ex}.";
                Console.Error.WriteLine(message);
#if NET462
                logger.LogError(message);
#else
                logger.LogError(ex, message);
#endif
            }
        }

        public CancellationTokenSource CreateCancellationTokenSource(string videoCaptureIdentifier)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSources.Add(videoCaptureIdentifier, cancellationTokenSource);
            return cancellationTokenSource;
        }

        public void AddVideoCaptureWithServer(string videoCaptureId, VideoCapture videoCapture, Server server)
        {
            videoCaptures.Add(videoCaptureId, videoCapture);
            cameraServers.Add(videoCaptureId, server);
        }

        public void Disconnect()
        {
            if (client != null && client.Socket != null)
            {
                client.Send($"{NetworkCommand.UnregisterAgent}|{client.Socket.LocalEndPoint}|{Dns.GetHostName()}", true);
                var displayManager = new DisplayManager();
                var displays = displayManager.GetAll();
                foreach (var display in displays)
                {
                    display.Host = client.Socket?.LocalEndPoint?.ToString();
                    client.Send($"{NetworkCommand.UnregisterDisplay}|{display.Serialize()}", true);
                }

                client.Dispose();
            }

            foreach (var videoCapture in videoCaptures)
            {
                try
                {
                    videoCapture.Value.Release();
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }

            foreach (var cameraServer in cameraServers)
            {
                try
                {
                    cameraServer.Value.Stop();
                    cameraServer.Value.Dispose();
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }

            foreach (var cameraProcess in cameraProcesses)
            {
                ProcessUtils.Kill(cameraProcess.Value);
            }

            foreach (var sequenceProcess in sequenceProcesses)
            {
                ProcessUtils.Kill(sequenceProcess.Value);
            }
        }

        private void SendVideoCaptureSourcesToLiveView()
        {
            client.Send($"{NetworkCommand.VideoCaptureSourcesResponse}|{String.Join(";", cameraServers.Select(kvp => $"{kvp.Key}={kvp.Value}"))}", true);
        }

        private int StartProcess(string[] messageParts, Dictionary<long, Process> processes)
        {
            var process = AppStarter.Start(messageParts[0], messageParts[1], logger);
            processes.Add(process.Id, process);
            return process.Id;
        }
    }
}
