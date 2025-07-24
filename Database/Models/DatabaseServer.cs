using Database.Services.PasswordHashers;
using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class DatabaseServer : IHaveId<int>
    {
        private string username;

        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string Hostname { get; set; }

        public string Username
        {
            get => DatabaseServerPasswordCryptor.UsernameDecrypt(username);
            set => username = value;
        }

        public string EncryptedUsername => username;

        public string Password { get; set; }

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
