using Mtf.Cryptography.SymmetricCiphers;
using System.Text;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class VideoServerPasswordCryptor
    {
        private static readonly AesCipher cipher = new AesCipher(Encoding.ASCII.GetBytes("u7O0c_'e~hre:i6~WUE!?WfH5Q~Kr@$6"), Encoding.ASCII.GetBytes("<g.?9w|6G*/v0Qpp"));

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
