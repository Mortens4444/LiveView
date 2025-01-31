using Database.Enums;
using Database.Models;

namespace LiveView.Dto
{
    public class CameraDto
    {
        public string Guid { get; set; }

        public string CameraName { get; set; }

        public string IpAddress { get; set; }

        public FullscreenMode FullscreenMode { get; set; }

        public int? StreamId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ServerUsername { get; set; }

        public string ServerPassword { get; set; }

        public bool Actual { get; set; }

        public ServerDto Server { get; set; }

        public long Id { get; set; }

        public long ServerId { get; set; }

        public int RecorderIndex { get; set; }

        public static CameraDto FromModel(Camera camera, Server server = null)
        {
            if (camera == null)
            {
                return null;
            }

            return new CameraDto
            {
                Id = camera.Id,
                Guid = camera.Guid,
                ServerId = camera.ServerId,
                StreamId = camera.StreamId,
                RecorderIndex = camera.RecorderIndex,
                IpAddress = camera.IpAddress,
                Username = camera.Username,
                Password = camera.Password,
                ServerUsername = camera.ServerUsername,
                ServerPassword = camera.ServerPassword,
                Actual = camera.Actual,
                CameraName = camera.CameraName,
                FullscreenMode = camera.FullscreenMode,
                Server = ServerDto.FromModel(server)
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
