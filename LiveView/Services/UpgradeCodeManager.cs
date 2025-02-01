using Mtf.HardwareKey.Enums;
using System;
using System.Security.Cryptography;
using System.Text;

namespace LiveView.Services
{
    public static class UpgradeCodeManager
    {
        public static bool ValidateUpgradeCode(string code, string secretKey, out LiveViewEdition edition)
        {
            try
            {
                var decodedData = Encoding.UTF8.GetString(Convert.FromBase64String(code));
                var parts = decodedData.Split('|');

                if (parts.Length != 4)
                {
                    edition = LiveViewEdition.Basic;
                    return false;
                }

                var generatedTime = Int64.Parse(parts[0]);
                var expiryTime = Int64.Parse(parts[1]);
                var signature = parts[3];
                edition = (LiveViewEdition)Byte.Parse(parts[2]);

                var rawData = $"{generatedTime}|{expiryTime}|{(byte)edition}";
                var expectedSignature = ComputeHmac(rawData, secretKey);

                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                
                return now >= generatedTime && now <= expiryTime && signature == expectedSignature;
            }
            catch
            {
                edition = LiveViewEdition.Basic;
                return false;
            }
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
