using Database.Models;

namespace Sequence.Dto
{
    public class AxVideoPictureCameraInfo : CameraInfo
    {
        public Database.Models.Camera Camera { get; set; }

        public Server Server { get; set; }
    }
}
