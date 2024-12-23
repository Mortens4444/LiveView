using Database.Models;
using Mtf.Enums.Camera;
using System.Data.Common;

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

        public bool Actual { get; set; }

        public ServerConnection ServerConnection { get; set; }

        public long Id { get; set; }

        public long ServerId { get; set; }

        public int RecorderIndex { get; set; }

        public static CameraDto FromModel(Camera camera)
        {
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
                Actual = camera.Actual,
                CameraName = camera.CameraName,
                FullscreenMode = camera.FullscreenMode,
                ServerConnection = camera.ServerConnection
            };
        }
    }
}
