using Database.Services.PasswordHashers;
using Mtf.Extensions.Interfaces;
using System;

namespace Database.Models
{
    public class Server : IHaveId<int>, IEquatable<Server>
    {
        private string username;
        private string winUser;

        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string Username
        {
            get => VideoServerPasswordCryptor.UsernameDecrypt(username);
            set => username = value;
        }

        public string EncryptedUsername => username;

        public string Password { get; set; }

        public string MacAddress { get; set; }

        public string Hostname { get; set; }

        public string DongleSn { get; set; }

        public string SerialNumber { get; set; }

        public string WinUser
        {
            get => WindowsPasswordCryptor.UsernameDecrypt(winUser);
            set => winUser = value;
        }

        public string EncryptedWinUser => winUser;

        public string WinPass { get; set; }

        public bool StartInMotionPopup { get; set; }

        public int VideoServerCredentialsId { get; set; }

        public int WindowsCredentialsId { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Server other && Equals(other);
        }

        public bool Equals(Server other)
        {
            return other != null && Id == other.Id;
        }
        public override string ToString()
        {
            return Hostname;
        }
    }
}
