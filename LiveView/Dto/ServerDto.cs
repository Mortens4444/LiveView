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

        public Credentials VideoServerCredentials { get; set; }

        public Server ToModel()
        {
            return new Server
            {
                IpAddress = IpAddress,
                Username = VideoServerCredentials.Username,
                Password = VideoServerCredentials.Password,
                MacAddress = MacAddress,
                Hostname = Hostname,
                DongleSn = DongleSerialNumber,
                SerialNumber = SerialNumber,
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
                VideoServerCredentials = new Credentials
                {
                    Username = server.Username,
                    Password = server.Password
                }
            };
        }

        public override string ToString()
        {
            return $"{Hostname} ({IpAddress}, {MacAddress})";
        }
    }
}
