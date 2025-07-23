using Database.Services.PasswordHashers;
using Mtf.Extensions.Interfaces;
using System;

namespace Database.Models
{
    public class User : IHaveId<int>
    {
        private string username;

        public int Id { get; set; }

        public string Username
        {
            get => UserPasswordHasher.UsernameDecrypt(username);
            set => username = value;
        }

        public string EncryptedUsername => username;

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }
        
        public string LicensePlate { get; set; }
        
        public string Barcode { get; set; }
        
        public string OtherInformation { get; set; }
        
        public byte[] Image { get; set; }
        
        public int SecondaryLogonPriority { get; set; }

        public int NeededSecondaryLogonPriority { get; set; }

        public int LoginCredentialsId { get; set; }

        public override string ToString()
        {
            if (String.IsNullOrWhiteSpace(Username))
            {
                return $"User Id: {Id}";
            }

            return Username;
        }
    }
}
