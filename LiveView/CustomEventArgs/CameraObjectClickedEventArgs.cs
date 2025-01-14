using Database.Models;

namespace LiveView.CustomEventArgs
{
    public class CameraObjectClickedEventArgs
    {
        public Camera Camera { get; private set; }

        public CameraObjectClickedEventArgs(Camera camera)
        {
            Camera = camera;
        }
    }
}
