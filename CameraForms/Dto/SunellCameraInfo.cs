using Database.Models;

namespace CameraForms.Dto
{
    public class SunellCameraInfo : CameraInfo
    {
        public string CameraIp { get; set; }

        public ushort CameraPort { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
