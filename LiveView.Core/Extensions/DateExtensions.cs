using System;

namespace LiveView.Core.Extensions
{
    public static class DateExtensions
    {
        public static string ToFriendlyString(this DateTime dateTime)
        {
            return $"{dateTime:yyyy.MM.dd HH:mm:ss}";
        }
    }
}
