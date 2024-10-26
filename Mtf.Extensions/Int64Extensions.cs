using System;

namespace Mtf.Extensions
{
    public static class Int64Extensions
    {
        public static TimeSpan ToTimeSpan(this Int64 value)
        {
            var ms = (int)value % 100;
            var totalSeconds = value / 100;

            var seconds = (int)(totalSeconds % 60);
            var minutes = (int)(totalSeconds / 60 % 60);
            var hours = (int)(totalSeconds / 3600 % 24);
            var days = (int)(totalSeconds / 86400);

            return new TimeSpan(days, hours, minutes, seconds, ms);
        }
    }
}
