using LiveView.Core.Services.PasswordHashers;

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
                IpAddress = IpAddress,
                Username = DatabaseServerPasswordCryptor.Decrypt(DatabaseServerCredentials.Username),
                Password = DatabaseServerPasswordCryptor.Decrypt(DatabaseServerCredentials.Password),
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
