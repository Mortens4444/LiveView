using System;
using System.Globalization;

namespace Mtf.Extensions
{
    public static class ObjectExtensions
    {
        public static bool ConvertToBoolean(this object value)
        {
            return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
        }

        public static byte ConvertToByte(this object value)
        {
            return Convert.ToByte(value, CultureInfo.InvariantCulture);
        }

        public static char ConvertToChar(this object value)
        {
            return Convert.ToChar(value, CultureInfo.InvariantCulture);
        }

        public static DateTime ConvertToDateTime(this object value)
        {
            return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
        }

        public static Int16 ConvertToInt16(this object value)
        {
            return Convert.ToInt16(value, CultureInfo.InvariantCulture);
        }

        public static int ConvertToInt32(this object value)
        {
            return Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        public static ushort ConvertToUInt16(this object value)
        {
            return Convert.ToUInt16(value, CultureInfo.InvariantCulture);
        }

        public static uint ConvertToUInt32(this object value)
        {
            return Convert.ToUInt32(value, CultureInfo.InvariantCulture);
        }

        public static UInt64 ConvertToUInt64(this object value)
        {
            return Convert.ToUInt64(value, CultureInfo.InvariantCulture);
        }

        public static Int64 ConvertToInt64(this object value)
        {
            return Convert.ToInt64(value, CultureInfo.InvariantCulture);
        }

        public static string ConvertToString(this object value)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }
    }
}
