using LiveView.Agent.Maui.Enums.Network;
using LiveView.Agent.Maui.Services;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Extensions;
using System.Net;
using Mtf.Network.Services;

namespace LiveView.Agent.Maui
{
    public class LiveViewConnector
    {
        private readonly string cameraCaptureServer;
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly string cameraIdentifier;
        private Client? client;

        public LiveViewConnector(string cameraIdentifier, string cameraCaptureServer, CancellationTokenSource cancellationTokenSource)
        {
            this.cameraIdentifier = cameraIdentifier;
            this.cancellationTokenSource = cancellationTokenSource;
            this.cameraCaptureServer = cameraCaptureServer;
        }

        public async Task ConnectAsync(string serverIp, ushort serverPort)
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    Console.WriteLine($"Attempt to connect {serverIp}:{serverPort}.");
                    client = new Client(serverIp, serverPort);
                    client.DataArrived += ClientDataArrivedEventHandlerAsync;
                    client.Connect();
                    var hostInfo = client.Socket?.LocalEndPoint?.GetEndPointInfo(NetUtils.GetLocalIPAddresses);
                    if (client.Send($"{NetworkCommand.RegisterAgent}|{hostInfo}|{Dns.GetHostName()}|0", true))
                    {
                        SendVideoCaptureSourcesToLiveView();

                        await Task.Run(async () =>
                        {
                            while (!cancellationTokenSource.IsCancellationRequested)
                            {
                                await Task.Delay(1000);
                                if (!client.Send($"{NetworkCommand.Ping}|{client.Socket?.LocalEndPoint}", true))
                                {
                                    break;
                                }
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Connection failed: {ex}");
                    await Task.Delay(5000);
                }
            }
        }

        private async void ClientDataArrivedEventHandlerAsync(object? sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client.Encoding.GetString(e.Data)}";
                var commands = MauiAgentCommandFactory.Create(this, cancellationTokenSource, messages);
                foreach (var command in commands)
                {
                    await command.ExecuteAsync();
                    Console.WriteLine($"{command.GetType().Name} executed in MAUI agent.");
                }
            }
            catch (Exception ex)
            {
                //logger.LogException(ex, "Client data cannot be parsed by MAUI agent.");
                var message = $"Message parse or execution failed in MAUI agent: {ex}.";
                Console.Error.WriteLine(message);
                //DebugErrorBox.Show(ex);
            }
        }

        public void SendVideoCaptureSourcesToLiveView()
        {
            client!.Send($"{NetworkCommand.VideoCaptureSourcesResponse}|{cameraIdentifier}={cameraCaptureServer}", true);
        }
    }
}
