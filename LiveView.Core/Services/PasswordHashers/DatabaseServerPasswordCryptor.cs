using Mtf.Cryptography.SymmetricCiphers;
using System.Text;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class DatabaseServerPasswordCryptor
    {
        private static readonly AesCipher cipher = new AesCipher(Encoding.ASCII.GetBytes(AppConfig.GetString(Constants.DatabaseServerPasswordCryptorKey)), Encoding.ASCII.GetBytes(AppConfig.GetString(Constants.DatabaseServerPasswordCryptorIV)));

        public static string Encrypt(string input)
        {
            return cipher.Encrypt(input);
        }

        public static string Decrypt(string input)
        {
            return cipher.Decrypt(input);
        }
    }
}
