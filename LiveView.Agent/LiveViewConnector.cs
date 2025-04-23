using Database.Interfaces;
using LiveView.Agent.Services;
using LiveView.Core.Enums.Network;
using LiveView.Core.Extensions;
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
                    var hostInfo = client?.Socket?.LocalEndPoint?.GetEndPointInfo();
                    if (client.Send($"{NetworkCommand.RegisterAgent}|{hostInfo}|{Dns.GetHostName()}|{vncServerPort}", true))
                    {
                        var displayManager = new DisplayManager();
                        var displays = displayManager.GetAll();
                        foreach (var display in displays)
                        {
                            display.Host = client.Socket.LocalEndPoint.ToString();
                            Console.WriteLine($"Registering display {display}.");
                            client.Send($"{NetworkCommand.RegisterDisplay}|{hostInfo}|{display.Serialize()}", true);
                        }

                        UpdateVideoCaptureSources(hostInfo, client.ListenerPortOfClient, vncServerPort);
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
                var commands = AgentCommandFactory.Create(logger, cameraServers, cameraProcesses, sequenceProcesses, client, e.Data, e.Socket, videoCaptures, cancellationTokenSources);
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
                var hostInfo = client?.Socket?.LocalEndPoint?.GetEndPointInfo();
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

        private void UpdateVideoCaptureSources(string localEndPointInfo, int agentPort, int vncServerPort)
        {
            client.Send($"{NetworkCommand.VideoCaptureSourcesResponse}|{String.Join(";", cameraServers.Select(kvp => $"{kvp.Key}={kvp.Value}"))}", true);

            List<Database.Models.VideoSource> relevantVideoSources;
            if (cameraServers.Count > 0)
            {
                var videoSources = videoSourceRepository.SelectAll();
                var agent = agentRepository.SelectWhere(new { ServerIp = localEndPointInfo.GetIpAddessFromEndPoint() }).FirstOrDefault();

                relevantVideoSources = videoSources.Where(videoSource => videoSource.AgentId == agent.Id).ToList();
                foreach (var cameraServer in cameraServers)
                {
                    long videoSourceId;
                    var foundVideoSource = relevantVideoSources.FirstOrDefault(vs => vs.Name == cameraServer.Key);
                    var videoSource = new Database.Models.VideoSource
                    {
                        AgentId = agent.Id,
                        Name = cameraServer.Key,
                        Port = cameraServer.Value.ListenerPortOfServer
                    };
                    if (foundVideoSource != null)
                    {
                        videoSource.Id = foundVideoSource.Id;
                        videoSourceId = foundVideoSource.Id;
                        videoSourceRepository.Update(videoSource);
                    }
                    else
                    {
                        videoSourceRepository.Insert(videoSource);
                    }
                }
            }
        }
    }
}
