namespace Database.Models
{
    public class DatabaseServerDto
    {
        public long Id { get; set; }

        public string Hostname { get; set; }

        public string IpAddress { get; set; }

        public string MacAddress { get; set; }

        public string DatabaseName { get; set; }

        public int DatabaseServerPort { get; set; }

        public Credentials DatabaseServerCredentials { get; set; }

        public DatabaseServer ToModel()
        {
            return new DatabaseServer
            {
                IpOrHost = IpAddress,
                DisplayedName = Hostname,
                Username = DatabaseServerCredentials.Username,
                Password = DatabaseServerCredentials.Password,
                MacAddress = MacAddress,
                Hostname = Hostname,
                DbName = DatabaseName,
                DbPort = DatabaseServerPort
            };
        }

        public override string ToString()
        {
            return $"{Hostname} ({IpAddress}, {MacAddress})";
        }
    }
}
