using Database.Models;

namespace Sequence.Dto
{
    public class AxVideoPictureCameraInfo : CameraInfo
    {
        public Camera Camera { get; set; }

        public VideoServer Server { get; set; }
    }
}
