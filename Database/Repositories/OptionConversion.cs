using Database.Enums;
using Database.Models;
using System;

namespace Database.Repositories;

/// <summary>Converts option values between their stored string form and typed values. Shared by the SQL and in-memory option repositories.</summary>
internal static class OptionConversion
{
    internal static T GetValue<T>(Setting settingName, GeneralOption setting)
    {
        try
        {
            switch (setting.TypeId)
            {
                case OptionType.Bool:
                case OptionType.Float:
                case OptionType.Int32:
                case OptionType.Int64:
                case OptionType.String:
                    return (T)Convert.ChangeType(setting.Value, typeof(T));
                default:
                    throw new NotSupportedException($"Type '{setting.TypeId}' is not supported yet.");
            }
        }
        catch (InvalidCastException)
        {
            throw new InvalidCastException($"The value for setting '{settingName}' cannot be converted to type {typeof(T).Name}.");
        }
    }

    internal static OptionType GetOptionType<T>(T value)
    {
        if (value is bool) return OptionType.Bool;
        if (value is float) return OptionType.Float;
        if (value is int) return OptionType.Int32;
        if (value is long) return OptionType.Int64;
        if (value is string) return OptionType.String;

        throw new NotSupportedException($"Unsupported type: {typeof(T).Name}");
    }
}
