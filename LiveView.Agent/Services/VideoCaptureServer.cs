using LiveView.Core.Extensions;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Controls.Video.OpenCvSharp;
using Mtf.MessageBoxes;
using Mtf.Network;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LiveView.Agent.Services
{
    public class VideoCaptureServer : IDisposable
    {
        public CancellationTokenSource CancellationTokenSource
        {
            get => cancellationTokenSource;
        }

        private CancellationTokenSource cancellationTokenSource;
        private int bufferSize;
        private ILogger<VideoCaptureServer> logger;
        private List<ImageCaptureServer> imageCaptureServers = new List<ImageCaptureServer>();
        private bool disposed;

        public VideoCaptureServer(IServiceProvider serviceProvider)
        {
            logger = serviceProvider.GetRequiredService<ILogger<VideoCaptureServer>>();
            bufferSize = AppConfig.GetInt32(Core.Constants.ImageCaptureServerBufferSize, 409600);
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                foreach (var imageCaptureServer in imageCaptureServers)
                {
                    imageCaptureServer.Dispose();
                }

                cancellationTokenSource?.CancelAndDispose();
            }

            disposed = true;
        }

        public void StartAll(LiveViewConnector liveViewConnector)
        {
            Console.WriteLine("Starting video capture servers...");
            var json = AppConfig.GetString(Core.Constants.StartCameras);
            var videoCaptureIds = Json.Deserialize<List<string>>(json);

            foreach (var videoCaptureId in videoCaptureIds)
            {
                Start(videoCaptureId, liveViewConnector);
            }
        }

        private void Start(string videoCaptureId, LiveViewConnector liveViewConnector)
        {
            try
            {
                Console.WriteLine($"Starting video capture server ({videoCaptureId})");
                var videoCapture = Int32.TryParse(videoCaptureId, out var videoCaptureIndex) ?
                    new VideoCapture(videoCaptureIndex) : new VideoCapture(videoCaptureId);

                // Cameras should have unique values
                //var exposure = generalOptionsRepository.Get<int>(Database.Enums.Setting.Exposure, 0);
                //videoCapture.Set(VideoCaptureProperties.Exposure, exposure); // -4, 1, 0.75

                //var brightness = generalOptionsRepository.Get<int>(Database.Enums.Setting.Brightness, 0);
                //videoCapture.Set(VideoCaptureProperties.Brightness, brightness); // 50 (scale 0–100)

                //var gain = generalOptionsRepository.Get<int>(Database.Enums.Setting.Gain, 0);
                //videoCapture.Set(VideoCaptureProperties.Gain, gain); // 10

                var imageCaptureServer = new ImageCaptureServer(new VideoCaptureImageSource(videoCapture), videoCaptureId)
                {
                    BufferSize = bufferSize
                };
                imageCaptureServers.Add(imageCaptureServer);
                imageCaptureServer.FPS = AppConfig.GeByte(Core.Constants.LiveViewAgentImageCaptureServerFps, 4);

                var videoCaptureServer = imageCaptureServer.StartVideoCaptureServer(cancellationTokenSource);
                //var videoCaptureServer = new VideoCaptureServer();
                //var server = videoCaptureServer.StartVideoCaptureServer(liveViewConnector, videoCapture, videoCaptureId);
                Console.WriteLine($"Video capture server ({videoCaptureId}): {videoCaptureServer}");
                liveViewConnector.AddVideoCaptureWithServer(videoCaptureId, videoCapture, videoCaptureServer);
                Console.Title = $"LiveView Agent: {videoCaptureServer}";
            }
            catch (Exception ex)
            {
                logger.LogException(ex, $"Start video capture server {videoCaptureId} failed.");
                ErrorBox.Show(ex);
            }
        }
    }
}
