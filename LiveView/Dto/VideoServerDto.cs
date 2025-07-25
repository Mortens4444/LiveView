using Database.Models;
using Database.Services.PasswordHashers;

namespace LiveView.Dto
{
    public class VideoServerDto
    {
        public long Id { get; set; }

        public string Hostname { get; set; }

        public string IpAddress { get; set; }

        public string MacAddress { get; set; }

        public string DongleSerialNumber { get; set; }

        public string SerialNumber { get; set; }

        public int WindowsCredentialsId { get; set; }

        public Credentials WindowsCredentials { get; set; }

        public int VideoServerCredentialsId { get; set; }

        public Credentials VideoServerCredentials { get; set; }

        public VideoServer ToModel()
        {
            return new VideoServer
            {
                IpAddress = IpAddress,
                EncryptedUsername = VideoServerCredentials.Username,
                EncryptedPassword = VideoServerCredentials.Password,
                MacAddress = MacAddress,
                Hostname = Hostname,
                DongleSn = DongleSerialNumber,
                SerialNumber = SerialNumber,
                EncryptedWinUser = WindowsCredentials.Username,
                EncryptedWinPass = WindowsCredentials.Password,
                StartInMotionPopup = false,
                VideoServerCredentialsId = VideoServerCredentialsId,
                WindowsCredentialsId = WindowsCredentialsId
            };
        }

        public static VideoServerDto FromModel(VideoServer server)
        {
            if (server == null)
            {
                return null;
            }

            return new VideoServerDto
            {
                Id = server.Id,
                DongleSerialNumber = server.DongleSn,
                Hostname = server.Hostname,
                IpAddress = server.IpAddress,
                MacAddress = server.MacAddress,
                SerialNumber = server.SerialNumber,
                WindowsCredentialsId = server.WindowsCredentialsId,
                VideoServerCredentialsId = server.VideoServerCredentialsId,
                WindowsCredentials = new Credentials
                {
                    Username = server.EncryptedWinUser,
                    Password = WindowsPasswordCryptor.PasswordDecrypt(server.EncryptedWinPass)
                },
                VideoServerCredentials = new Credentials
                {
                    Username = server.EncryptedUsername,
                    Password = VideoServerPasswordCryptor.PasswordDecrypt(server.EncryptedPassword)
                }
            };
        }

        public override string ToString()
        {
            return $"{Hostname} ({IpAddress}, {MacAddress})";
        }
    }
}
