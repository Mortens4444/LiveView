using LiveView.Core.Enums.Network;
using Mtf.Network;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LiveView.Agent
{
    public static class VideoCaptureServer
    {
        public static Server Capture(Dictionary<string, CancellationTokenSource> cancellationTokenSources, VideoCapture videoCapture, string videoCaptureIdentifier, byte fps = 25)
        {
            const int maxRetryCount = 3; // Maximum újraindítási próbálkozások száma
            int retryCount = 0;

            var server = new Server();
            Thread.Sleep(100);
            server.Start();
            server.SetBufferSize(409600);

            Task.Run(() =>
            {
                while (retryCount < maxRetryCount)
                {
                    try
                    {
                        using (var capture = videoCapture)
                        {
                            var cancellationTokenSource = new CancellationTokenSource();
                            cancellationTokenSources.Add(videoCaptureIdentifier, cancellationTokenSource);

                            while (!cancellationTokenSource.Token.IsCancellationRequested)
                            {
                                if (!CaptureFrame(server, videoCaptureIdentifier, capture))
                                {
                                    break;
                                }

                                var waitTime = 1000 / fps;
                                Thread.Sleep(waitTime);
                            }
                        }

                        // Sikeres végrehajtás esetén kilépünk a retry loop-ból
                        break;
                    }
                    catch (Exception ex)
                    {
                        retryCount++;
                        try
                        {
                            server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureCreationFailure}|{videoCaptureIdentifier}|{ex}", true);
                        }
                        catch { }

                        if (retryCount < maxRetryCount)
                        {
                            Thread.Sleep(2000); // Rövid várakozás az újraindítás előtt
                        }
                        else
                        {
                            server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureCreationFailure}|{videoCaptureIdentifier}|Max retry attempts reached", true);
                        }
                    }
                }
            });

            return server;
        }

        private static bool CaptureFrame(Server server, string videoCaptureIdentifier, VideoCapture capture)
        {
            using (var frame = new Mat())
            {
                if (capture.Read(frame) && !frame.Empty())
                {
                    SendData(server, frame.ToBytes());

                    //var gray = frame.CvtColor(ColorConversionCodes.BGR2GRAY);
                    //var equalized = new Mat();
                    //Cv2.EqualizeHist(gray, equalized);
                    //SendData(server, equalized.ToBytes());

                    return true;
                }

                server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureFailure}|{videoCaptureIdentifier}", true);
                return false;
            }
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
