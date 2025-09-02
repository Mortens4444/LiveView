using LiveView.Agent.Dto;
using LiveView.Agent.Services;
using LiveView.Core.Enums.Network;
using LiveView.Core.Extensions;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Extensions;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Network.Services;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LiveView.Agent
{
    public class LiveViewConnector : IDisposable
    {
        private const string PressCtrlCToExit = "Press Ctrl+C to exit.";
        
        private readonly Dictionary<long, ProcessInfo> cameraProcesses = new Dictionary<long, ProcessInfo>();
        private readonly Dictionary<long, ProcessInfo> sequenceProcesses = new Dictionary<long, ProcessInfo>();
        private readonly Dictionary<string, VideoCapture> videoCaptures = new Dictionary<string, VideoCapture>();
        private readonly Dictionary<string, Server> cameraServers = new Dictionary<string, Server>(); // cameraServers and videoCaptures should be in the same dictionary
        private readonly Dictionary<string, CancellationTokenSource> cancellationTokenSources = new Dictionary<string, CancellationTokenSource>();

        private readonly ILogger<LiveViewConnector> logger;
        private readonly IDisplayManager displayManager;

        private Client client;
        private bool disposed;

        public LiveViewConnector(ILogger<LiveViewConnector> logger,
            IDisplayManager displayManager)
        {
            this.logger = logger;
            this.displayManager = displayManager;
        }

        ~LiveViewConnector()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    client?.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task ConnectAsync(string serverIp, ushort serverPort, ushort vncServerPort, CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Console.WriteLine($"Attempt to connect {serverIp}:{serverPort}.");
                    client = new Client(serverIp, serverPort);
                    client.DataArrived += ClientDataArrivedEventHandler;
                    client.Connect();
                    var hostInfo = client.Socket?.LocalEndPoint?.GetEndPointInfo(NetUtils.GetLocalIPAddresses);
                    if (client.Send($"{NetworkCommand.RegisterAgent}|{hostInfo}|{Dns.GetHostName()}|{vncServerPort}", true))
                    {
                        var displays = displayManager.GetAll();
                        foreach (var display in displays)
                        {
                            display.Host = client.Socket.LocalEndPoint.ToString();
                            Console.WriteLine($"Registering display {display}.");
                            client.Send($"{NetworkCommand.RegisterDisplay}|{hostInfo}|{display.Serialize()}", true);
                        }

                        client.Send($"{NetworkCommand.VideoCaptureSourcesResponse}|{String.Join(";", cameraServers.Select(kvp => $"{kvp.Key}={kvp.Value}"))}", true);

                        Console.WriteLine($"Connected to server {serverIp}:{serverPort}.");
                        Console.WriteLine(PressCtrlCToExit);

                        while (!cancellationToken.IsCancellationRequested)
                        {
                            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                            if (!client.Send($"{NetworkCommand.Ping}|{hostInfo}", true))
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    client.Disconnect();
                    logger?.LogError(ex, "Agent connection failed.");
                    Console.Error.WriteLine($"Connection failed: {ex}");
                }

                await Task.Delay(5000, cancellationToken).ConfigureAwait(false);
            }
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var commands = AgentCommandFactory.Create(logger, cameraServers, cameraProcesses, sequenceProcesses, client, e.Data, videoCaptures, cancellationTokenSources);
                foreach (var command in commands)
                {
                    command.Execute();
                    Console.WriteLine($"{command.GetType().Name} executed in agent.");
                }
            }
            catch (Exception ex)
            {
                var message = $"Message parse or execution failed in agent: {ex}.";
                Console.Error.WriteLine(message);
                logger?.LogException(ex, message);
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
                var hostInfo = client.Socket?.LocalEndPoint?.GetEndPointInfo(NetUtils.GetLocalIPAddresses);
                client.Send($"{NetworkCommand.UnregisterAgent}|{hostInfo}|{Dns.GetHostName()}", true);
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
                Core.Services.ProcessUtils.Kill(cameraProcess.Value.Process);
            }

            foreach (var sequenceProcess in sequenceProcesses)
            {
                Core.Services.ProcessUtils.Kill(sequenceProcess.Value.Process);
            }
        }
    }
}
