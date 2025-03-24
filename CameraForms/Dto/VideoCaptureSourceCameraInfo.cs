using Database.Models;

namespace CameraForms.Dto
{
    public class VideoCaptureSourceCameraInfo : CameraInfo
    {
        public string ServerIp { get; set; }

        public string VideoSourceName { get; set; }

        public override string ToString()
        {
            return $"{ServerIp}:{VideoSourceName}";
        }
    }
}
