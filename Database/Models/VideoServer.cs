using Database.Services.PasswordHashers;
using Mtf.Extensions.Interfaces;
using System;

namespace Database.Models
{
    public class VideoServer : IHaveId<int>, IEquatable<VideoServer>
    {
        private string encryptedUsername;
        private string encryptedWinUser;

        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string Username => VideoServerPasswordCryptor.UsernameDecrypt(encryptedUsername);

        public string EncryptedUsername
        {
            get => encryptedUsername;
            set => encryptedUsername = value;
        }

        public string EncryptedPassword { get; set; }

        public string MacAddress { get; set; }

        public string Hostname { get; set; }

        public string DongleSn { get; set; }

        public string SerialNumber { get; set; }

        public string WinUser => WindowsPasswordCryptor.UsernameDecrypt(encryptedWinUser);

        public string EncryptedWinUser
        {
            get => encryptedWinUser;
            set => encryptedWinUser = value;
        }

        public string EncryptedWinPass { get; set; }

        public bool StartInMotionPopup { get; set; }

        public int VideoServerCredentialsId { get; set; }

        public int WindowsCredentialsId { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is VideoServer other && Equals(other);
        }

        public bool Equals(VideoServer other)
        {
            return other != null && Id == other.Id;
        }
        public override string ToString()
        {
            return Hostname;
        }
    }
}
