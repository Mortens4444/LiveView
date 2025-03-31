using Mtf.Network.Interfaces;
using OpenCvSharp;
using System.Threading;
using System.Threading.Tasks;

namespace LiveView.Agent
{
    public class VideoCaptureImageSource : IImageSource
    {
        private readonly VideoCapture videoCapture;

        public VideoCaptureImageSource(VideoCapture videoCapture)
        {
            this.videoCapture = videoCapture;
        }

        public Task<byte[]> CaptureAsync(CancellationToken token)
        {
            using (var frame = new Mat())
            {
                if (videoCapture.Read(frame) && !frame.Empty())
                {
                    return Task.FromResult(frame.ToBytes());
                }
            }
            return Task.FromResult<byte[]>(null);
        }
    }
}
