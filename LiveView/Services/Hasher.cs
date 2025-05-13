using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LiveView.Services
{
    public static class Hasher
    {
        public static string GetFileSha256Hash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    var hashBytes = sha256.ComputeHash(fileStream);
                    var sb = new StringBuilder(hashBytes.Length * 2);
                    foreach (var b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }
    }
}
