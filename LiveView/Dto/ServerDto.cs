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
                Username = VideoServerCredentials.UserName,
                Password = VideoServerCredentials.Password,
                MacAddress = MacAddress,
                Hostname = Hostname,
                DongleSn = DongleSerialNumber,
                SerialNumber = SerialNumber,
                StartInMotionPopup = false
            };
        }

        public override string ToString()
        {
            return $"{Hostname} ({IpAddress}, {MacAddress})";
        }
    }
}
