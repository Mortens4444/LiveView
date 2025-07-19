using Mtf.Cryptography.Interfaces;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class DatabaseServerPasswordCryptor
    {
        private static readonly ICipher cipher = CipherFactory.CreateCipher(Constants.DatabaseServerPasswordCryptorKey, Constants.DatabaseServerPasswordCryptorIV);

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
