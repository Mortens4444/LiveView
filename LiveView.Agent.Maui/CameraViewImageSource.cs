using Camera.MAUI;

namespace LiveView.Agent.Maui
{
    public class CameraViewImageSource : Mtf.Network.Interfaces.IImageSource
    {
        private readonly CameraView cameraView;

        public CameraViewImageSource(CameraView cameraView)
        {
            this.cameraView = cameraView;
        }

        public Task<byte[]> CaptureAsync(CancellationToken token)
        {
            var snapshot = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
            return ImageSourceToByteArrayAsync(snapshot, token);
        }

        private static async Task<byte[]> ImageSourceToByteArrayAsync(ImageSource imageSource, CancellationToken token = default)
        {
            if (imageSource is StreamImageSource streamImageSource)
            {
                var stream = await streamImageSource.Stream(token);
                if (stream != null)
                {
                    using var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream, token);
                    return memoryStream.ToArray();
                }
            }

            return Array.Empty<byte>();
        }
    }
}
