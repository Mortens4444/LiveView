using System;

namespace LiveView.Core.Extensions
{
    public static class StringExtensions
    {
        public static string GetIpAddessFromEndPoint(this string text)
        {
            return text.Split(':')[0];
        }

        public static ushort GetPortFromEndPoint(this string text)
        {
            if (UInt16.TryParse(text.Split(':')[1], out var port))
            {
                return port;
            }
            throw new ArgumentException($"Port value cannot be parsed from value: {text}.");
        }
    }
}
