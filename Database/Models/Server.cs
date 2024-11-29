namespace Database.Models
{
    public class Server
    {
        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string MacAddress { get; set; }

        public string Hostname { get; set; }

        public string DongleSn { get; set; }

        public string SerialNumber { get; set; }

        public bool StartInMotionPopup { get; set; }

        public static Server From(ServerDto server)
        {
            return new Server
            {
                IpAddress = server.IpAddress,
                Username = server.VideoServerCredentials.UserName,
                Password = server.VideoServerCredentials.Password,
                MacAddress = server.MacAddress,
                Hostname = server.Hostname,
                DongleSn = server.DongleSerialNumber,
                SerialNumber = server.SerialNumber,
                StartInMotionPopup = false
            };
        }

        public override string ToString()
        {
            return Hostname;
        }
    }
}
