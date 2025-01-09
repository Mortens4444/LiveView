using Database.Enums;
using Database.Models;
using Mtf.Database;
using System;

namespace Database.Repositories
{
    public abstract class BaseOptionsRepository<TOptionType> : BaseRepository<TOptionType>
        where TOptionType : GeneralOption
    {
        protected static T GetValue<T>(Setting settingName, TOptionType setting)
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
                        throw new NotImplementedException($"Type '{setting.TypeId}' is not supported.");
                }
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException($"The value for setting '{settingName}' cannot be converted to type {typeof(T).Name}.");
            }
        }

        protected static OptionType GetOptionType<T>(T value)
        {
            if (value is bool) return OptionType.Bool;
            if (value is float) return OptionType.Float;
            if (value is int) return OptionType.Int32;
            if (value is long) return OptionType.Int64;
            if (value is string) return OptionType.String;

            throw new NotSupportedException($"Unsupported type: {typeof(T).Name}");
        }
    }
}
