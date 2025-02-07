using System;
using System.Security.Cryptography;
using System.Text;

namespace LiveView.Services
{
    public static class UniqueIdGenerator
    {
        public static long Get(Enum @enum)
        {
            return Get(String.Concat(@enum.GetType().Name, @enum));
        }


        public static long Get(string input)
        {
            var hashBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToInt64(hashBytes, 0);
        }
    }
}
