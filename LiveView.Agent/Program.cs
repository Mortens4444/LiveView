using LiveView.Agent.Services;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using Mtf.Network;
using Mtf.Network.EventArg;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace LiveView.Agent
{
    class Program
    {
        private const string PressCtrlCToExit = "Press Ctrl+C to exit.";
        private static Client client;
        private static ILogger<ExceptionHandler> logger;

        private static readonly Dictionary<long, Process> cameraProcesses = new Dictionary<long, Process>();
        private static readonly Dictionary<long, Process> sequenceProcesses = new Dictionary<long, Process>();
        private static readonly Dictionary<string, CancellationTokenSource> cancellationTokenSources = new Dictionary<string, CancellationTokenSource>();
        private static readonly Dictionary<string, Server> cameraServers = new Dictionary<string, Server>(); // cameraServers and videoCaptures should be in the same dictionary
        private static readonly Dictionary<string, VideoCapture> videoCaptures = new Dictionary<string, VideoCapture>();
        //private static readonly GeneralOptionsRepository generalOptionsRepository;
        private static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();
        
        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static Program()
        {
            DatabaseInitializer.Initialize("LiveViewConnectionString");
            //generalOptionsRepository = new GeneralOptionsRepository();
        }

        static void Main(string[] args)
        {
            ExceptionHandler.CatchUnhandledExceptions();
            using (var serviceProvider = ServiceProviderFactory.Create())
            {
                logger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();
                ExceptionHandler.SetLogger(logger);
            }

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();

#if !DEBUG
            const int SW_HIDE = 0;
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
#endif
            StartVideoCaptureServers();

            var serverIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
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
                                client.Send($"{NetworkCommand.RegisterDisplay}|{display.Serialize()}", true);
                            }

                            SendVideoCaptureSourcesToLiveView();
                            Console.WriteLine($"Connected to server {serverIp}:{serverPort}.");
                            Console.WriteLine(PressCtrlCToExit);

                            while (true)
                            {
                                Thread.Sleep(1000);
                                if (!client.Send($"{NetworkCommand.Ping}", true))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Agent connection failed.");
                        Console.Error.WriteLine($"Connection failed: {ex}");
                        Thread.Sleep(5000);
                    }
                }
            }
            else
            {
                var message = "LiveViewServer.ListenerPort cannot be parsed as an ushort.";
                logger.LogError(message);
                ErrorBox.Show("General error", message);
            }
        }

        private static void StartVideoCaptureServers()
        {
            var json = ConfigurationManager.AppSettings["StartCameras"];
            var videoCaptureIds = JsonSerializer.Deserialize<List<string>>(json);
            foreach (var videoCaptureId in videoCaptureIds)
            {
                try
                {
                    var videoCapture = Int32.TryParse(videoCaptureId, out var videoCaptureIndex) ?
                        new VideoCapture(videoCaptureIndex) : new VideoCapture(videoCaptureId);

                    // Cameras should have uniques values
                    //var exposure = generalOptionsRepository.Get<int>(Database.Enums.Setting.Exposure, 0);
                    //videoCapture.Set(VideoCaptureProperties.Exposure, exposure); // -4, 1, 0.75

                    //var brightness = generalOptionsRepository.Get<int>(Database.Enums.Setting.Brightness, 0);
                    //videoCapture.Set(VideoCaptureProperties.Brightness, brightness); // 50 (scale 0–100)

                    //var gain = generalOptionsRepository.Get<int>(Database.Enums.Setting.Gain, 0);
                    //videoCapture.Set(VideoCaptureProperties.Gain, gain); // 10

                    videoCaptures.Add(videoCaptureId, videoCapture);
                    var server = VideoCaptureServer.Capture(cancellationTokenSources, videoCapture, videoCaptureId);
                    cameraServers.Add(videoCaptureId, server);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Start video capture servers failed.");
                    ErrorBox.Show(ex);
                }
            }
        }

        private static void OnExit()
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
                videoCapture.Value.Release();
            }

            foreach (var cameraServer in cameraServers)
            {
                cameraServer.Value.Stop();
                cameraServer.Value.Dispose();
            }

            foreach (var cameraProcess in cameraProcesses)
            {
                ProcessUtils.Kill(cameraProcess.Value);
            }

            foreach (var sequenceProcess in sequenceProcesses)
            {
                ProcessUtils.Kill(sequenceProcess.Value);
            }

            Application.Exit();
        }

        private static void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client?.Encoding.GetString(e.Data)}";
                var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var message in allMessages)
                {
                    var messageParts = message.Split('|');

                    if (message.StartsWith($"{Core.Constants.CameraAppExe}|", StringComparison.InvariantCulture))
                    {
                        var cameraProcessId = StartProcess(messageParts, cameraProcesses);
                        client.Send($"{NetworkCommand.SendCameraProcessId}|{cameraProcessId}", true);
                    }
                    else if (message.StartsWith($"{Core.Constants.SequenceExe}|", StringComparison.InvariantCulture))
                    {
                        StartProcess(messageParts, sequenceProcesses);
                    }
                    else if (message.StartsWith($"{NetworkCommand.Kill}|", StringComparison.InvariantCulture))
                    {
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
                logger.LogError(ex, "Message parse or execution failed in agent.");
                Console.Error.WriteLine($"Message parse or execution failed: {ex}");
            }
        }

        private static void SendVideoCaptureSourcesToLiveView()
        {
            client.Send($"{NetworkCommand.VideoCaptureSourcesResponse}|{String.Join(";", cameraServers.Select(kvp => $"{kvp.Key}={kvp.Value}"))}", true);
        }

        private static int StartProcess(string[] messageParts, Dictionary<long, Process> processes)
        {
            var process = AppStarter.Start(messageParts[0], messageParts[1], logger);
            var parameters = messageParts[1].Split();
            var entityId = Convert.ToInt64(parameters[1], CultureInfo.InvariantCulture);
            processes.Add(entityId, process);
            return process.Id;
        }
    }
}