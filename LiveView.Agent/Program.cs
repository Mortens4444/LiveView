using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
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
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace LiveView.Agent
{
    class Program
    {
        private const string PressCtrlCToExit = "Press Ctrl+C to exit.";
        private static Client client;

        private static readonly Dictionary<long, Process> cameraProcesses = new Dictionary<long, Process>();
        private static readonly Dictionary<long, Process> sequenceProcesses = new Dictionary<long, Process>();
        private static readonly Dictionary<string, CancellationTokenSource> cancellationTokenSources = new Dictionary<string, CancellationTokenSource>();
        private static readonly Dictionary<string, Server> cameraServers = new Dictionary<string, Server>();

        private static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();

        static void Main(string[] args)
        {
            ExceptionHandler.CatchUnhandledExceptions();
            Console.CancelKeyPress += Console_CancelKeyPress;

            StartVideoCaptureServers();

            var serverIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                while (true)
                {
                    try
                    {
                        client = new Client(serverIp, serverPort);
                        client.DataArrived += ClientDataArrivedEventHandler;
                        client.Connect();
                        client.Send($"{NetworkCommand.RegisterAgent}|{client.Socket.LocalEndPoint}|{Dns.GetHostName()}", true);

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
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Connection failed: {ex}");
                        Thread.Sleep(5000);
                    }
                }
            }
            else
            {
                ErrorBox.Show("General error", "LiveViewServer.ListenerPort cannot be parsed as an ushort.");
            }
        }

        private static void StartVideoCaptureServers()
        {
            var json = ConfigurationManager.AppSettings["StartCameras"];
            var videoCaptureIds = JsonSerializer.Deserialize<List<string>>(json);
            //var videoCaptureIds = new[] { "0", "1", "2", "3", @"E:\Video\Natasha Bedingfield - Pocketful of Sunshine (Official Video).mp4" };
            foreach (var videoCaptureId in videoCaptureIds)
            {
                try
                {
                    var server = Int32.TryParse(videoCaptureId, out var videoCaptureIndex) ?
                        VideoCaptureServer.Capture(cancellationTokenSources, new VideoCapture(videoCaptureIndex), videoCaptureId) :
                        VideoCaptureServer.Capture(cancellationTokenSources, new VideoCapture(videoCaptureId), videoCaptureId);
                    //Capture(VideoCapture.FromFile(videoCaptureId), videoCaptureId);
                    cameraServers.Add(videoCaptureId, server);
                }
                catch (Exception ex)
                {
                    ErrorBox.Show(ex);
                }
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (client != null && client.Socket != null)
            {
                client.Send($"{NetworkCommand.UnregisterAgent}|{client.Socket.LocalEndPoint}|{Dns.GetHostName()}", true);
                var displayManager = new DisplayManager();
                var displays = displayManager.GetAll();
                foreach (var display in displays)
                {
                    display.Host = client.Socket.LocalEndPoint.ToString();
                    client.Send($"{NetworkCommand.UnregisterDisplay}|{display.Serialize()}", true);
                }

                client.Dispose();
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

                    if (message.StartsWith($"{Core.Constants.CameraExe}|", StringComparison.InvariantCulture))
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
                            case Core.Constants.CameraExe:
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
                        var processes = messageParts[1] == Core.Constants.CameraExe ? cameraProcesses.Values : sequenceProcesses.Values;
                        ProcessUtils.Kill(processes);
                    }
                    else if (message.StartsWith($"{NetworkCommand.VideoCaptureSourcesRequest}|", StringComparison.InvariantCulture))
                    {
                        SendVideoCaptureSourcesToLiveView();
                    }
                    //else if (message.StartsWith($"{NetworkCommand.VideoCaptureFileServe}|", StringComparison.InvariantCulture))
                    //{
                    //    var server = VideoCaptureServer.Capture(cancellationTokenSources, new VideoCapture(messageParts[1]), messageParts[1]);
                    //}
                    //else if (message.StartsWith($"{NetworkCommand.VideoCapture}|", StringComparison.InvariantCulture))
                    //{
                    //    if (Int32.TryParse(messageParts[1], out var videoCaptureIndex))
                    //    {
                    //        var server = VideoCaptureServer.Capture(cancellationTokenSources, new VideoCapture(videoCaptureIndex), videoCaptureIndex.ToString(CultureInfo.CurrentCulture));
                    //    }
                    //}
                    else if (message.StartsWith($"{NetworkCommand.StopVideoCapture}|", StringComparison.InvariantCulture))
                    {
                        if (cancellationTokenSources.TryGetValue(messageParts[1], out var value))
                        {
                            value.Cancel();
                            cancellationTokenSources.Remove(messageParts[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Message parse or execution failed: {ex}");
            }
        }

        private static void SendVideoCaptureSourcesToLiveView()
        {
            client.Send($"{NetworkCommand.VideoCaptureSourcesResponse}|{String.Join(";", cameraServers.Select(kvp => $"{kvp.Key}={kvp.Value}"))}", true);
        }

        private static int StartProcess(string[] messageParts, Dictionary<long, Process> processes)
        {
            var process = AppStarter.Start(messageParts[0], messageParts[1]);
            var parameters = messageParts[1].Split();
            var entityId = Convert.ToInt64(parameters[1], CultureInfo.InvariantCulture);
            processes.Add(entityId, process);
            return process.Id;
        }
    }
}