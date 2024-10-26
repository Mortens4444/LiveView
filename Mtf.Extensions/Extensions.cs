using System;

namespace Mtf.Extensions
{
    public static class Extensions
    {
        public static T LimitMe<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return value.CompareTo(min) < 0 ? min : value.CompareTo(max) > 0 ? max : value;
        }
    }
}
