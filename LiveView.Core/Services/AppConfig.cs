using System;
using System.Configuration;

namespace LiveView.Core.Services
{
    public static class AppConfig
    {
        public static T GetWithThrowOnError<T>(string settingName, T defaultValue = default)
        {
            var value = ConfigurationManager.AppSettings[settingName];
            if (String.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            if (typeof(T) == typeof(string))
            {
                return (T)(object)value;
            }

            if (typeof(T) == typeof(bool) && Boolean.TryParse(value, out var b))
            {
                return (T)(object)b;
            }

            if (typeof(T) == typeof(sbyte) && SByte.TryParse(value, out var sby))
            {
                return (T)(object)sby;
            }

            if (typeof(T) == typeof(byte) && Byte.TryParse(value, out var by))
            {
                return (T)(object)by;
            }

            if (typeof(T) == typeof(short) && Int16.TryParse(value, out var s))
            {
                return (T)(object)s;
            }

            if (typeof(T) == typeof(ushort) && UInt16.TryParse(value, out var us))
            {
                return (T)(object)us;
            }

            if (typeof(T) == typeof(int) && Int32.TryParse(value, out var i))
            {
                return (T)(object)i;
            }

            if (typeof(T) == typeof(uint) && UInt32.TryParse(value, out var ui))
            {
                return (T)(object)ui;
            }

            if (typeof(T) == typeof(long) && Int64.TryParse(value, out var l))
            {
                return (T)(object)l;
            }

            if (typeof(T) == typeof(ulong) && UInt64.TryParse(value, out var ul))
            {
                return (T)(object)ul;
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T Get<T>(string settingName, T defaultValue = default)
        {
            try
            {
                return GetWithThrowOnError(settingName, defaultValue);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool GetBoolean(string name, bool defaultValue = default) => Get(name, defaultValue);

        public static bool GetBooleanWithThrowOnError(string name, bool defaultValue = default) => GetWithThrowOnError(name, defaultValue);

        public static sbyte GeSByte(string name, sbyte defaultValue = default) => Get(name, defaultValue);

        public static sbyte GetSByteWithThrowOnError(string name, sbyte defaultValue = default) => Get(name, defaultValue);

        public static byte GeByte(string name, byte defaultValue = default) => Get(name, defaultValue);

        public static byte GetByteWithThrowOnError(string name, byte defaultValue = default) => Get(name, defaultValue);

        public static short GetInt16(string name, short defaultValue = default) => Get(name, defaultValue);

        public static short GetInt16WithThrowOnError(string name, short defaultValue = default) => Get(name, defaultValue);

        public static ushort GetUInt16(string name, ushort defaultValue = default) => Get(name, defaultValue);

        public static ushort GetUInt16WithThrowOnError(string name, ushort defaultValue = default) => Get(name, defaultValue);

        public static int GetInt32(string name, int defaultValue = default) => Get(name, defaultValue);

        public static int GetInt32WithThrowOnError(string name, int defaultValue = default) => Get(name, defaultValue);

        public static uint GetUInt32(string name, uint defaultValue = default) => Get(name, defaultValue);

        public static uint GetUInt32WithThrowOnError(string name, uint defaultValue = default) => Get(name, defaultValue);

        public static long GetInt64(string name, long defaultValue = default) => Get(name, defaultValue);

        public static long GetInt64WithThrowOnError(string name, long defaultValue = default) => Get(name, defaultValue);

        public static ulong GetUInt64(string name, ulong defaultValue = default) => Get(name, defaultValue);

        public static ulong GetUInt64WithThrowOnError(string name, ulong defaultValue = default) => Get(name, defaultValue);

        public static string GetString(string name, string defaultValue = "") => Get(name, defaultValue);

        public static string GetStringWithThrowOnError(string name, string defaultValue = "") => Get(name, defaultValue);
    }
}
