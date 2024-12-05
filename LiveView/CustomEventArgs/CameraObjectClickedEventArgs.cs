using LiveView.Dto;

namespace LiveView.CustomEventArgs
{
    public class CameraObjectClickedEventArgs
    {
        public CameraDto Camera { get; private set; }

        public CameraObjectClickedEventArgs(CameraDto camera)
        {
            Camera = camera;
        }
    }
}
