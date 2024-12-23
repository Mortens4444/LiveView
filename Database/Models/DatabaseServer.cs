namespace Database.Models
{
    public class DatabaseServer
    {
        public long Id { get; set; }

        public string IpAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string MacAddress { get; set; }

        public string Hostname { get; set; }

        public string DatabaseName { get; set; }

        public int DatabaseServerPort { get; set; }
    }
}
