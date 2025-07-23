using Mtf.Cryptography.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Database.Services.PasswordHashers
{
    public static class UserPasswordHasher
    {
        private static readonly ICipher cipher = CipherFactory.CreateCipher(Constants.UserPasswordCryptorKey, Constants.UserPasswordCryptorIV);

        public static string Hash(string input)
        {
            return Sha256Hash(Reverse(Sha256Hash(Encrypt(input))));
        }

        public static string UsernameEncrypt(string input)
        {
            return Encrypt(Encrypt(input));
        }

        private static string Encrypt(string input)
        {
            return Reverse(cipher.Encrypt(input));
        }

        public static string UsernameDecrypt(string input)
        {
            return Decrypt(Decrypt(input));
        }

        private static string Decrypt(string input)
        {
            return cipher.Decrypt(Reverse(input));
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
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            var chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
