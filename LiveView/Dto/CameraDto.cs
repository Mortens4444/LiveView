using Database.Enums;
using Database.Models;

namespace LiveView.Dto
{
    public class CameraDto
    {
        public string Guid { get; set; }

        public string CameraName { get; set; }

        public string IpAddress { get; set; }

        public CameraMode FullscreenMode { get; set; }

        public int? StreamId { get; set; }

        public string EncryptedUsername { get; set; }

        public string EncryptedPassword { get; set; }

        public string ServerDisplayName { get; set; }

        public string ServerEncryptedUsername { get; set; }

        public string ServerEncryptedPassword { get; set; }

        public bool Actual { get; set; }

        public VideoServerDto Server { get; set; }

        public int Id { get; set; }

        public int VideoServerId { get; set; }

        public int RecorderIndex { get; set; }

        public static CameraDto FromModel(Camera camera, VideoServer server = null)
        {
            if (camera == null)
            {
                return null;
            }

            return new CameraDto
            {
                Id = camera.Id,
                Guid = camera.Guid,
                VideoServerId = camera.VideoServerId,
                StreamId = camera.StreamId,
                RecorderIndex = camera.RecorderIndex,
                IpAddress = camera.IpAddress,
                EncryptedUsername = camera.EncryptedUsername,
                EncryptedPassword = camera.EncryptedPassword,
                ServerDisplayName = camera.ServerDisplayName,
                ServerEncryptedUsername = camera.ServerEncryptedUsername,
                ServerEncryptedPassword = camera.ServerEncryptedPassword,
                Actual = camera.Actual,
                CameraName = camera.CameraName,
                FullscreenMode = camera.FullscreenMode,
                Server = VideoServerDto.FromModel(server)
            };
        }

        public override string ToString()
        {
            if (Server == null)
            {
                return CameraName;
            }

            return $"{Server.Hostname} - {CameraName}";
        }
    }
}
