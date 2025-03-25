using Camera.MAUI;
using LiveView.Agent.Maui.Enums.Network;
using Mtf.Network;
using System.Text;

namespace LiveView.Agent.Maui
{
    public static class CameraCaptureServer
    {
        public static Server Capture(
            Dictionary<string, CancellationTokenSource> cancellationTokenSources,
            CameraView cameraView,
            string cameraIdentifier,
            byte fps = 25)
        {
            const int maxRetryCount = 3;
            int retryCount = 0;

            var server = new Server();
            Thread.Sleep(100);
            server.Start();
            server.SetBufferSize(409600);

            Task.Run(async () =>
            {
                var delay = 1000 / fps;
                while (retryCount < maxRetryCount)
                {
                    try
                    {
                        var cancellationTokenSource = new CancellationTokenSource();
                        cancellationTokenSources.Add(cameraIdentifier, cancellationTokenSource);

                        await CaptureAndSendLoop(server, cameraView, cameraIdentifier, delay, cancellationTokenSource.Token);
                        break;
                    }
                    catch (Exception ex)
                    {
                        retryCount++;
                        try
                        {
                            server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureCreationFailure}|{cameraIdentifier}|{ex}", true);
                        }
                        catch { }

                        if (retryCount < maxRetryCount)
                        {
                            await Task.Delay(2000);
                        }
                        else
                        {
                            server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureCreationFailure}|{cameraIdentifier}|Max retry attempts reached", true);
                        }
                    }
                }
            });

            return server;
        }

        private static async Task CaptureAndSendLoop(Server server, CameraView cameraView, string cameraIdentifier, int delay, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var photo = await cameraView.CaptureAsync();
                    if (photo != null)
                    {
                        using var stream = await photo.OpenReadAsync();
                        using var memoryStream = new MemoryStream();
                        await stream.CopyToAsync(memoryStream);
                        var imageBytes = memoryStream.ToArray();

                        SendData(server, imageBytes);
                    }
                }
                catch (Exception ex)
                {
                    server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureFailure}|{cameraIdentifier}|{ex.Message}", true);
                }

                await Task.Delay(delay, token);
            }
        }

        public static void SendBarcode(Server server, string barcode)
        {
            var message = $"{NetworkCommand.BarcodeDetected}|{barcode}";
            var messageBytes = Encoding.UTF8.GetBytes(message);
            SendData(server, messageBytes);
        }

        private static void SendData(Server server, byte[] data)
        {
            var chunkSize = server.Socket.SendBufferSize - 500;
            var totalParts = (int)Math.Ceiling((double)data.Length / chunkSize);
            for (int i = 0; i < totalParts; i++)
            {
                var offset = i * chunkSize;
                var partSize = Math.Min(chunkSize, data.Length - offset);
                var partBytes = new byte[partSize];
                Buffer.BlockCopy(data, offset, partBytes, 0, partSize);
                server.SendBytesToAllClients(partBytes, true);
            }
        }
    }
}
