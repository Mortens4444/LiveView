using Database.Services.PasswordHashers;

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

        public int DatabaseServerCredentialsId { get; set; }

        public Credentials DatabaseServerCredentials { get; set; }

        public DatabaseServer ToModel()
        {
            return new DatabaseServer
            {
                IpAddress = IpAddress,
                EncryptedUsername = DatabaseServerCredentials.Username,
                EncryptedPassword = DatabaseServerCredentials.Password,
                MacAddress = MacAddress,
                Hostname = Hostname,
                DbName = DatabaseName,
                DbPort = DatabaseServerPort,
                DatabaseServerCredentialsId = DatabaseServerCredentialsId
            };
        }

        public override string ToString()
        {
            return $"{Hostname} ({IpAddress}, {MacAddress})";
        }
    }
}
