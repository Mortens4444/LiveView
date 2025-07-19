using Mtf.Cryptography.Interfaces;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class CameraPasswordCryptor
    {
        private static readonly ICipher cipher = CipherFactory.CreateCipher(Constants.CameraPasswordCryptorKey, Constants.CameraPasswordCryptorIV);

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
