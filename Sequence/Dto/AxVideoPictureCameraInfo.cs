using Database.Models;

namespace Sequence.Dto
{
    public class AxVideoPictureCameraInfo : CameraInfo
    {
        public Camera Camera { get; set; }

        public Server Server { get; set; }
    }
}
