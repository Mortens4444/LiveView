//using Camera.MAUI;
//using LiveView.Agent.Maui.Enums.Network;
//using Mtf.Network;

//namespace LiveView.Agent.Maui
//{
//    public class CameraCaptureServer
//    {
//        private const int maxRetryCount = 3;
//        private const int fps = 25;

//        private CameraView cameraView;
//        private string cameraIdentifier;

//        public CameraCaptureServer(CameraView cameraView, string cameraIdentifier)
//        {
//            this.cameraView = cameraView;
//            this.cameraIdentifier = cameraIdentifier;
//        }

//        public Server StartVideoCaptureServer(CancellationTokenSource cancellationTokenSource)
//        {
//            int retryCount = 0;

//            var server = new Server();
//            _ = Task.Delay(100, cancellationTokenSource.Token);
//            server.Start();
//            server.SetBufferSize(409600);

//            Task.Run(async () =>
//            {
//                var waitTime = 1000 / fps;
//                while (retryCount < maxRetryCount)
//                {
//                    try
//                    {
//                        await CaptureAndSendLoop(server, cameraView, cameraIdentifier, waitTime, cancellationTokenSource.Token);
//                    }
//                    catch (Exception ex)
//                    {
//                        retryCount++;
//                        try
//                        {
//                            server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureCreationFailure}|{cameraIdentifier}|{ex}", true);
//                        }
//                        catch { }

//                        if (retryCount < maxRetryCount)
//                        {
//                            _ = Task.Delay(2000, cancellationTokenSource.Token);
//                        }
//                        else
//                        {
//                            server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureCreationFailure}|{cameraIdentifier}|Max retry attempts reached", true);
//                        }
//                    }
//                }
//            });

//            return server;
//        }

//        private static async Task CaptureAndSendLoop(Server server, CameraView cameraView, string cameraIdentifier, int delay, CancellationToken token)
//        {
//            while (!token.IsCancellationRequested)
//            {
//                try
//                {
//                    var photo = await cameraView.CaptureAsync();
//                    if (photo != null)
//                    {
//                        using var stream = await photo.OpenReadAsync();
//                        using var memoryStream = new MemoryStream();
//                        await stream.CopyToAsync(memoryStream);
//                        var imageBytes = memoryStream.ToArray();

//                        server.SendBytesInChunksToAllClients(imageBytes);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureFailure}|{cameraIdentifier}|{ex.Message}", true);
//                }

//                await Task.Delay(delay, token);
//            }
//        }

//        //public static void SendBarcode(Server server, string barcode)
//        //{
//        //    var message = $"{NetworkCommand.BarcodeDetected}|{barcode}";
//        //    var messageBytes = Encoding.UTF8.GetBytes(message);
//        //    server.SendBytesInChunksToAllClients(messageBytes);
//        //}
//    }
//}
