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

        public override string ToString()
        {
            return $"{Hostname} ({IpAddress}, {MacAddress})";
        }
    }
}
