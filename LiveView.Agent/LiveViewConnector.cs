using Database.Interfaces;
using LiveView.Agent.Services;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Network.Extensions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private readonly ILogger<LiveViewConnector> logger;
        private readonly IAgentRepository agentRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        
        private Client client;

        public LiveViewConnector(ILogger<LiveViewConnector> logger, IAgentRepository agentRepository, IVideoSourceRepository videoSourceRepository)
        {
            this.logger = logger;
            this.agentRepository = agentRepository;
            this.videoSourceRepository = videoSourceRepository;
        }

        public async Task ConnectAsync(string serverIp, ushort serverPort, CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Console.WriteLine($"Attempt to connect {serverIp}:{serverPort}.");
                    client = new Client(serverIp, serverPort);
                    client.DataArrived += ClientDataArrivedEventHandler;
                    client.Connect();
                    var hostInfo = client.Socket.GetLocalIPAddressesInfo("|");
                    if (client.Send($"{NetworkCommand.RegisterAgent}|{hostInfo}|{Dns.GetHostName()}", true))
                    {
                        var displayManager = new DisplayManager();
                        var displays = displayManager.GetAll();
                        foreach (var display in displays)
                        {
                            display.Host = client.Socket.LocalEndPoint.ToString();
                            Console.WriteLine($"Registering display {display}.");
                            client.Send($"{NetworkCommand.RegisterDisplay}|{hostInfo}|{display.Serialize()}", true);
                        }

                        UpdateVideoCaptureSources();
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
                var commands = CommandFactory.Create(logger, cameraServers, cameraProcesses, sequenceProcesses, client, e.Data, e.Socket, videoCaptures, cancellationTokenSources);
                foreach (var command in commands)
                {
                    command.Execute();
                }
            }
            catch (Exception ex)
            {
                var message = $"Message parse or execution failed in agent: {ex}.";
                Console.Error.WriteLine(message);
#if NET462
                logger?.LogError(message);
#else
                logger?.LogError(ex, message);
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
                var hostInfo = client.Socket.GetLocalIPAddressesInfo("|");
                client.Send($"{NetworkCommand.UnregisterAgent}|{hostInfo}|{Dns.GetHostName()}", true);
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

        private void UpdateVideoCaptureSources()
        {
            SendVideoCaptureSourcesToLiveView();

            List<Database.Models.VideoSource> relevantVideoSources;
            if (cameraServers.Count > 0)
            {
                var videoSources = videoSourceRepository.SelectAll();
                var hostInfo = cameraServers.First().Value.ToString().Split(':');

                relevantVideoSources = videoSources.Where(videoSource => videoSource.ServerIp == hostInfo[0]).ToList();
                foreach (var relevantVideoSource in relevantVideoSources)
                {
                    agentRepository.DeleteWhere(new { VideoSourceId = relevantVideoSource.Id });
                }

                foreach (var cameraServer in cameraServers)
                {
                    hostInfo = cameraServer.Value.ToString().Split(':');
                    long videoSourceId;
                    var foundVideoSource = relevantVideoSources.FirstOrDefault(vs => vs.VideoSourceName == cameraServer.Key);
                    if (foundVideoSource != null)
                    {
                        videoSourceId = foundVideoSource.Id;
                    }
                    else
                    {
                        videoSourceId = videoSourceRepository.InsertAndReturnId<long>(new Database.Models.VideoSource
                        {
                            VideoSourceName = cameraServer.Key,
                            ServerIp = hostInfo[0]
                        });
                    }
                    var agent = agentRepository.SelectWhere(new { VideoSourceId = videoSourceId }).FirstOrDefault();
                    if (Int32.TryParse(hostInfo[1], out var port))
                    {
                        var newAgent = new Database.Models.Agent
                        {
                            Id = agent?.Id ?? 0,
                            VideoSourceId = videoSourceId,
                            Port = port
                        };
                        if (agent == null)
                        {
                            agentRepository.Insert(newAgent);
                        }
                        else
                        {
                            agentRepository.Update(newAgent);
                        }
                    }
                }
            }
        }
    }
}
