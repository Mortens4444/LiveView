using Database.Models;

namespace CameraForms.Dto
{
    public class SunellLegacyCameraInfo : CameraInfo
    {
        public const int PagoPort = 30001;

        public string CameraIp { get; set; }

        public ushort CameraPort { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int StreamId { get; set; }

        public int CameraId { get; set; }
    }
}
