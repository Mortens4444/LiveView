using Mtf.Cryptography.SymmetricCiphers;
using System.Text;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class WindowsPasswordCryptor
    {
        private static readonly AesCipher cipher = new AesCipher(Encoding.ASCII.GetBytes(AppConfig.GetString(Constants.WindowsPasswordCryptorKey)), Encoding.ASCII.GetBytes(AppConfig.GetString(Constants.WindowsPasswordCryptorIV)));

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
