using System;
using System.Security.Cryptography;
using System.Text;

namespace LiveView.Services
{
    public static class UniqueIdGenerator
    {
        public static int Get(Enum @enum)
        {
            return Get(String.Concat(@enum.GetType().Name, @enum));
        }

        public static int Get(string input)
        {
            var hashBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToInt32(hashBytes, 0);
        }
    }
}
