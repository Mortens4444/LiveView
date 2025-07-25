using Database.Services.PasswordHashers;
using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class DatabaseServer : IHaveId<int>
    {
        private string encryptedUsername;

        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string Hostname { get; set; }

        public string Username => DatabaseServerPasswordCryptor.UsernameDecrypt(encryptedUsername);

        public string EncryptedUsername
        {
            get => encryptedUsername;
            set => encryptedUsername = value;
        }

        public string EncryptedPassword { get; set; }

        public string MacAddress { get; set; }

        public string DbName { get; set; }

        public int DbPort { get; set; }

        public int DatabaseServerCredentialsId { get; set; }

        public override string ToString()
        {
            return Hostname;
        }
    }
}
