using LiveView.Agent.Maui.Enums.Network;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Network.Extensions;
using System.Net;

namespace LiveView.Agent.Maui
{
    public class LiveViewConnector
    {
        private string cameraCaptureServer;
        private Client? client;
        private CancellationTokenSource cancellationTokenSource;
        private string cameraIdentifier;

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
                    var hostInfo = client.Socket?.LocalEndPoint?.GetEndPointInfo();
                    if (client.Send($"{NetworkCommand.RegisterAgent}|{hostInfo}|{Dns.GetHostName()}|0", true))
                    {
                        SendVideoCaptureSourcesToLiveView();

                        await Task.Run(async () =>
                        {
                            while (!cancellationTokenSource.IsCancellationRequested)
                            {
                                await Task.Delay(1000);
                                if (!client.Send($"{NetworkCommand.Ping}|{client.Socket.LocalEndPoint}", true))
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
                var messages = $"{client?.Encoding.GetString(e.Data)}";
                var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var message in allMessages)
                {
                    var messageParts = message.Split('|');

                    if (message.StartsWith("CameraApp.exe|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Start CameraApp.exe", "OK");
                    }
                    else if (message.StartsWith("Sequence.exe|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Start Sequence.Exe", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.Kill}|", StringComparison.InvariantCulture))
                    {
                        Environment.Exit(0);
                    }
                    else if (message.StartsWith($"{NetworkCommand.KillAll}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Kill all", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.VideoCaptureSourcesRequest}|", StringComparison.InvariantCulture))
                    {
                        SendVideoCaptureSourcesToLiveView();
                    }
                    else if (message.StartsWith($"{NetworkCommand.StopVideoCapture}|", StringComparison.InvariantCulture))
                    {
                        cancellationTokenSource.Cancel();
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToEast}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Pan to east", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.TiltToNorth}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Tilt to north", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToEastAndTiltToNorth}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Pan to east and tilt to south", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToWestAndTiltToNorth}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Pan to west and tilt to north", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.MoveToPresetZero}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Move to preset zero", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.TiltToSouth}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Tilt to south", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToEastAndTiltToSouth}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Pan to east and tilt to south", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToWestAndTiltToSouth}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Pan to west and tilt to south", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.PanToWest}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Pan to west", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.StopPanAndTilt}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Stop pan and tilt", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.StopZoom}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Stop zoom", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.ZoomIn}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Zoom in", "OK");
                    }
                    else if (message.StartsWith($"{NetworkCommand.ZoomOut}|", StringComparison.InvariantCulture))
                    {
                        await Application.Current.MainPage.DisplayAlert("Information", "Zoom out", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Message parse or execution failed: {ex}");
            }
        }

        private void SendVideoCaptureSourcesToLiveView()
        {
            client!.Send($"{NetworkCommand.VideoCaptureSourcesResponse}|{cameraIdentifier}={cameraCaptureServer}", true);
        }
    }
}
