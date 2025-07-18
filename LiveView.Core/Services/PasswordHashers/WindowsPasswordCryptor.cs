using Mtf.Cryptography.SymmetricCiphers;
using System.Text;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class WindowsPasswordCryptor
    {
        private static readonly AesCipher cipher = new AesCipher(Encoding.ASCII.GetBytes("t8O0c*'e~hr5:it~WUE!?WfH5Q~Kr@$6"), Encoding.ASCII.GetBytes("<g:?9w|7G*/v3Qkp"));

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
