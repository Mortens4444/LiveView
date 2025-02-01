using System.Security.Cryptography;
using System.Text;

namespace UpgradeCodeGenerator
{
    public static class UpgradeCodeManager
    {
        public static string GenerateUpgradeCode(string secretKey, LiveViewEdition edition, int expiryMinutes)
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var expiry = now + (expiryMinutes * 60);
            var rawData = $"{now}|{expiry}|{(byte)edition}";

            var signature = ComputeHmac(rawData, secretKey);
            var fullData = $"{rawData}|{signature}";

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(fullData));
        }

        private static string ComputeHmac(string data, string secretKey)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
