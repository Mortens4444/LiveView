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
    }
}
