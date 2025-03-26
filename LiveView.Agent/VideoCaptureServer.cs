using LiveView.Core.Enums.Network;
using Mtf.Network;
using OpenCvSharp;
using System;
using System.Threading.Tasks;

namespace LiveView.Agent
{
    public class VideoCaptureServer
    {
        private const int maxRetryCount = 3;
        private const int fps =25;

        public Server StartVideoCaptureServer(LiveViewConnector liveViewConnector, VideoCapture videoCapture, string videoCaptureIdentifier)
        {
            int retryCount = 0;

            var server = new Server();
            Task.Delay(100);
            server.Start();
            server.SetBufferSize(409600);

            Task.Run(() =>
            {
                var waitTime = 1000 / fps;
                while (retryCount < maxRetryCount)
                {
                    try
                    {
                        CaptureAndSendLoop(liveViewConnector, videoCapture, videoCaptureIdentifier, server, waitTime);

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
                            _ = Task.Delay(2000);
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

        private static void CaptureAndSendLoop(LiveViewConnector liveViewConnector, VideoCapture videoCapture, string videoCaptureIdentifier, Server server, int waitTime)
        {
            using (var capture = videoCapture)
            {
                var cancellationTokenSource = liveViewConnector.CreateCancellationTokenSource(videoCaptureIdentifier);
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    if (!CaptureFrame(server, videoCaptureIdentifier, capture))
                    {
                        break;
                    }

                    Task.Delay(waitTime);
                }
            }
        }

        private static bool CaptureFrame(Server server, string videoCaptureIdentifier, VideoCapture capture)
        {
            using (var frame = new Mat())
            {
                if (capture.Read(frame) && !frame.Empty())
                {
                    server.SendBytesInChunksToAllClients(frame.ToBytes(), 500);

                    //var gray = frame.CvtColor(ColorConversionCodes.BGR2GRAY);
                    //var equalized = new Mat();
                    //Cv2.EqualizeHist(gray, equalized);
                    //server.SendBytesInChunksToAllClients(equalized.ToBytes(), 500);

                    return true;
                }

                server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureFailure}|{videoCaptureIdentifier}", true);
                return false;
            }
        }
    }
}
