using Mtf.Cryptography.Interfaces;

namespace LiveView.Core.Services.PasswordHashers
{
    public class NoCryptor : ICipher
    {
        public string Decrypt(string cipherText)
        {
            return cipherText;
        }

        public byte[] Decrypt(byte[] cipherBytes)
        {
            return cipherBytes;
        }

        public string Encrypt(string plainText)
        {
            return plainText;
        }

        public byte[] Encrypt(byte[] plainBytes)
        {
            return plainBytes;
        }
    }
}
