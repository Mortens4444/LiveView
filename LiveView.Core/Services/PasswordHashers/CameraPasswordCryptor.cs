using Mtf.Cryptography.SymmetricCiphers;
using System.Text;

namespace LiveView.Core.Services.PasswordHashers
{
    public static class CameraPasswordCryptor
    {
        private static readonly AesCipher cipher = new AesCipher(Encoding.ASCII.GetBytes("7gz0c_'e~f6r:i6~QWS!?S4Eq1~Kr@$6"), Encoding.ASCII.GetBytes("<g.?8w|6G*/v0Qpp"));

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
