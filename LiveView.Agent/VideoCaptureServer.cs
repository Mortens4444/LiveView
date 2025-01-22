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
            var server = new Server();
            server.Start();
            server.SetBufferSize(409600);

            Task.Run(() =>
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
                }
                catch (Exception ex)
                {
                    try
                    {
                        server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureCreationFailure}|{videoCaptureIdentifier}|{ex}", true);
                    }
                    catch { }
                }
            });

            return server;
        }

        private static bool CaptureFrame(Server server, string videoCaptureIdentifier, VideoCapture capture)
        {
            using (var mat = new Mat())
            {
                if (capture.Read(mat) && !mat.Empty())
                {
                    var bytes = mat.ToBytes();
                    SendData(server, videoCaptureIdentifier, bytes);
                    return true;
                }

                server.SendMessageToAllClients($"{NetworkCommand.VideoCaptureFailure}|{videoCaptureIdentifier}", true);
                return false;
            }
        }

        private static void SendData(Server server, string videoCaptureIdentifier, byte[] data)
        {
            var chunkSize = server.Socket.SendBufferSize - 500;
            var totalParts = (int)Math.Ceiling((double)data.Length / chunkSize);
            for (int i = 0; i < totalParts; i++)
            {
                //var headerBytes = server.Encoding.GetBytes($"{NetworkCommand.FrameArrived}|{videoCaptureIdentifier}|{i + 1}|{totalParts}|");
                var offset = i * chunkSize;
                var partSize = Math.Min(chunkSize, data.Length - offset);
                //var partBytes = new byte[partSize + headerBytes.Length];
                var partBytes = new byte[partSize];
                //Buffer.BlockCopy(headerBytes, 0, partBytes, 0, headerBytes.Length);
                //Buffer.BlockCopy(data, offset, partBytes, headerBytes.Length, partSize);
                Buffer.BlockCopy(data, offset, partBytes, 0, partSize);
                server.SendBytesToAllClients(partBytes, true);
            }
        }
    }
}
