using Database.Enums;
using Database.Interfaces;

namespace Database.Models
{
    public class Camera : IHaveGuid, IHaveId<long>
    {
        public long Id { get; set; }

        public long? PartnerCameraId { get; set; }

        public string Guid { get; set; }

        public string CameraName { get; set; }

        public string IpAddress { get; set; }

        public FullscreenMode FullscreenMode { get; set; }

        public int? StreamId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ServerUsername { get; set; }

        public string ServerPassword { get; set; }

        public string HttpStreamUrl { get; set; }

        public bool Actual { get; set; }

        public long ServerId { get; set; }

        public long? MotionTrigger { get; set; }

        public long? MotionTriggerMinimumLength { get; set; }

        public int Priority { get; set; }

        public int RecorderIndex { get; set; }

        public override string ToString()
        {
            return CameraName;
        }
    }
}
