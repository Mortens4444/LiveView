using Database.Models;

namespace Sequence.Dto
{
    public class CameraInfo
    {
        public GridCamera GridCamera { get; set; }

        public Camera Camera { get; set; }

        public Server Server { get; set; }
    }
}
