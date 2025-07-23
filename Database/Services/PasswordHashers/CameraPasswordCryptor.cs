using Mtf.Cryptography.Interfaces;

namespace Database.Services.PasswordHashers
{
    public static class CameraPasswordCryptor
    {
        private static readonly ICipher cipher = CipherFactory.CreateCipher(Constants.CameraPasswordCryptorKey, Constants.CameraPasswordCryptorIV);

        public static string UsernameEncrypt(string input)
        {
            return Encrypt(Encrypt(input));
        }

        public static string PasswordEncrypt(string input)
        {
            return Encrypt(Encrypt(Encrypt(input)));
        }

        public static string UsernameDecrypt(string input)
        {
            return Decrypt(Decrypt(input));
        }

        public static string PasswordDecrypt(string input)
        {
            return Decrypt(Decrypt(Decrypt(input)));
        }

        private static string Encrypt(string input)
        {
            return cipher.Encrypt(input);
        }

        private static string Decrypt(string input)
        {
            return cipher.Decrypt(input);
        }
    }
}
