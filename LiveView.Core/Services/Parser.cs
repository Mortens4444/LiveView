using Database.Enums;
using System;
using System.Globalization;

namespace LiveView.Core.Services
{
    public static class Parser
    {
        public static CameraMode ConvertToCameraMode(string value)
        {
            return (CameraMode)Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        public static CameraMode ToCameraMode(string value)
        {
            if (Int32.TryParse(value, out var cameraModeNumber))
            {
                return (CameraMode)cameraModeNumber;
            }

            return CameraMode.AxVideoPlayer;
        }

        public static int ToInt32(string value)
        {
            if (Int32.TryParse(value, out var number))
            {
                return number;
            }
            throw new ArgumentException($"Unable to parse Int32 value from: {value}");
        }

        public static long ToInt64(string value)
        {
            if (Int64.TryParse(value, out var number))
            {
                return number;
            }
            throw new ArgumentException($"Unable to parse Int64 value from: {value}");
        }

        public static long? ToNullableInt64(string value)
        {
            return !String.IsNullOrEmpty(value) ? (long?)ToInt64(value) : null;
        }
    }
}
