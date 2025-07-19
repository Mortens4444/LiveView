using Mtf.Cryptography.Interfaces;
using Mtf.Cryptography.SymmetricCiphers;
using System;
using System.Text;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class CipherFactory
    {
        public static ICipher CreateCipher(string keyConfigName, string ivConfigName)
        {
            var key = AppConfig.GetString(keyConfigName);
            var iv = AppConfig.GetString(ivConfigName);
            if (String.IsNullOrEmpty(key) || String.IsNullOrEmpty(iv))
            {
                return new NoCryptor();
            }
            return new AesCipher(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(iv));
        }
    }
}
