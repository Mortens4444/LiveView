using Mtf.Cryptography.SymmetricCiphers;
using System;
using System.Security.Cryptography;
using System.Text;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class UserPasswordHasher
    {
        private static readonly VigenereCipher cipher = new VigenereCipher("_9U|{m8J#5'O");

        public static string Hash(string input)
        {
            return Sha256Hash(Reverse(Sha256Hash(Reverse(cipher.Encrypt(input)))));
        }

        public static string Sha256Hash(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", String.Empty).ToLowerInvariant();
            }
        }

        public static string Reverse(string input)
        {
            var chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
