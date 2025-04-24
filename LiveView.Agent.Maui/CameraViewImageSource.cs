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

        public async Task<byte[]> CaptureAsync(CancellationToken token)
        {
            var photo = await cameraView.CaptureAsync();
            if (photo != null)
            {
                using var stream = await photo.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream, token);
                return memoryStream.ToArray();
            }
            return Array.Empty<byte>();
        }
    }
}
