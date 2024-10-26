using System;
using System.Security.Cryptography;

namespace Mtf.Extensions.Services
{
    public static class RandomProvider
    {
        public static double GetSecureRandomDouble()
        {
            var bytes = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            var randomInt = BitConverter.ToInt32(bytes, 0) & 0x7FFFFFFF;
            return (double)randomInt / 10_000_000;
        }
    }
}
