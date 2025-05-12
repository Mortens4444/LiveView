using LiveView.Core.Extensions;
using System;

namespace LiveView.Core.Services
{
    public static class DateUtils
    {
        public static string GetNowFriendlyString()
        {
            return $"{Environment.NewLine}{DateTime.Now.ToFriendlyString()}";
        }

        public static string GetUtcNowFriendlyString()
        {
            return $"{Environment.NewLine}{DateTime.UtcNow.ToFriendlyString()}";
        }
    }
}
