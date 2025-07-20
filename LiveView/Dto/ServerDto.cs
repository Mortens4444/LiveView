using Database.Services.PasswordHashers;

namespace Database.Models
{
    public class ServerDto
    {
        public long Id { get; set; }

        public string Hostname { get; set; }

        public string IpAddress { get; set; }

        public string MacAddress { get; set; }

        public string DongleSerialNumber { get; set; }

        public string SerialNumber { get; set; }

        public Credentials WindowsCredentials { get; set; }

        public Credentials VideoServerCredentials { get; set; }

        public Server ToModel()
        {
            return new Server
            {
                IpAddress = IpAddress,
                Username = VideoServerPasswordCryptor.Encrypt(VideoServerCredentials.Username),
                Password = VideoServerPasswordCryptor.Encrypt(VideoServerCredentials.Password),
                MacAddress = MacAddress,
                Hostname = Hostname,
                DongleSn = DongleSerialNumber,
                SerialNumber = SerialNumber,
                WinUser = WindowsPasswordCryptor.Encrypt(WindowsCredentials.Username),
                WinPass = WindowsPasswordCryptor.Encrypt(WindowsCredentials.Password),
                StartInMotionPopup = false
            };
        }

        public static ServerDto FromModel(Server server)
        {
            if (server == null)
            {
                return null;
            }

            return new ServerDto
            {
                Id = server.Id,
                DongleSerialNumber = server.DongleSn,
                Hostname = server.Hostname,
                IpAddress = server.IpAddress,
                MacAddress = server.MacAddress,
                SerialNumber = server.SerialNumber,
                WindowsCredentials = new Credentials
                {
                    Username = WindowsPasswordCryptor.Decrypt(server.WinUser),
                    Password = WindowsPasswordCryptor.Decrypt(server.WinPass)
                },
                VideoServerCredentials = new Credentials
                {
                    Username = VideoServerPasswordCryptor.Decrypt(server.Username),
                    Password = VideoServerPasswordCryptor.Decrypt(server.Password)
                }
            };
        }

        public override string ToString()
        {
            return $"{Hostname} ({IpAddress}, {MacAddress})";
        }
    }
}
