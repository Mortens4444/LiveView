using Database.Models;
using System.Drawing;

namespace Sequence.Dto
{
    public class ScreenCaptureCameraInfo : CameraInfo
    {
        public Rectangle RecordingArea { get; set; }
    }
}
