using Mtf.Cryptography.SymmetricCiphers;
using System.Text;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class CameraPasswordCryptor
    {
        private static readonly AesCipher cipher = new AesCipher(Encoding.ASCII.GetBytes(AppConfig.GetString(Constants.CameraPasswordCryptorKey)), Encoding.ASCII.GetBytes(AppConfig.GetString(Constants.CameraPasswordCryptorIV)));

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
