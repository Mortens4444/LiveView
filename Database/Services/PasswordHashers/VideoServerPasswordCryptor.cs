using Mtf.Cryptography.Interfaces;

namespace Database.Services.PasswordHashers
{
    public static class VideoServerPasswordCryptor
    {
        private static readonly ICipher cipher = CipherFactory.CreateCipher(Constants.VideoServerPasswordCryptorKey, Constants.VideoServerPasswordCryptorIV);

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
