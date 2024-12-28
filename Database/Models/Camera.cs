using Database.Interfaces;
using Mtf.Enums.Camera;

namespace Database.Models
{
    public class Camera : IHaveGuid, IHaveId<long>
    {
        public long Id { get; set; }

        public string Guid { get; set; }

        public string CameraName { get; set; }

        public string IpAddress { get; set; }

        public FullscreenMode FullscreenMode { get; set; }

        public int? StreamId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool Actual { get; set; }

        public ServerConnection ServerConnection { get; set; }

        public long ServerId { get; set; }

        public int RecorderIndex { get; set; }
    }
}
