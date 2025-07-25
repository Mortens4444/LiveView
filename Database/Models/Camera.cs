using Database.Enums;
using Database.Services.PasswordHashers;
using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Camera : IHaveGuid, IHaveId<int>
    {
        private string encryptedUsername;

        public int Id { get; set; }

        public int? PartnerCameraId { get; set; }

        public int ServerId { get; set; }

        public string Guid { get; set; }

        public string CameraName { get; set; }

        public string IpAddress { get; set; }

        public CameraMode FullscreenMode { get; set; }

        public int? StreamId { get; set; }

        public string Username => CameraPasswordCryptor.UsernameDecrypt(encryptedUsername);

        public string EncryptedUsername
        {
            get => encryptedUsername;
            set => encryptedUsername = value;
        }

        public string EncryptedPassword { get; set; }

        public string ServerDisplayName { get; set; }

        public string ServerEncryptedUsername { get; set; }

        public string ServerEncryptedPassword { get; set; }

        public string HttpStreamUrl { get; set; }

        public bool Actual { get; set; }

        public long? MotionTrigger { get; set; }

        public long? MotionTriggerMinimumLength { get; set; }

        public int Priority { get; set; }

        public int RecorderIndex { get; set; }

        public int? CameraId { get; set; }

        public long? VideoSourceId { get; set; }

        public long PermissionCamera { get; set; }

        public int CameraServerCredentialsId { get; set; }

        //public int VideoServerCredentialsId { get; set; }

        public override string ToString()
        {
            return $"{ServerDisplayName} - {CameraName}";
        }
    }
}
