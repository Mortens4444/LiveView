using System;

namespace LiveView.Core.Extensions
{
    public static class StringExtensions
    {
        private static readonly char[] separator = new char[] { ':', ' ' };

        public static string GetIpAddessFromEndPoint(this string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return String.Empty;
            }
            return text.Split(':')[0];
        }

        public static ushort GetPortFromEndPoint(this string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return 0;
            }
            if (UInt16.TryParse(text.Split(separator)[1], out var port))
            {
                return port;
            }
            throw new ArgumentException($"Port value cannot be parsed from value: {text}.");
        }

        public static Tuple<string, string> GetVideoSourceInfo(this string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return new Tuple<string, string>(String.Empty, String.Empty);
            }
            var info = text.Split('|');
            if (info.Length == 2)
            {
                return new Tuple<string, string>(info[0], info[1]);
            }
            throw new ArgumentException($"Video source info cannot be parsed from value: {text}.");
        }
    }
}
