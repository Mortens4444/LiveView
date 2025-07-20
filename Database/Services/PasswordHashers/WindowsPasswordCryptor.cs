using Mtf.Cryptography.Interfaces;

namespace Database.Services.PasswordHashers
{
    public static class WindowsPasswordCryptor
    {
        private static readonly ICipher cipher = CipherFactory.CreateCipher(Constants.WindowsPasswordCryptorKey, Constants.WindowsPasswordCryptorIV);

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
