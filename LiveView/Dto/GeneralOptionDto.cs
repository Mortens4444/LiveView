using Database.Enums;
using Database.Models;
using System;

namespace LiveView.Dto
{
    public class GeneralOptionDto
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public OptionType Type { get; set; }

        public T GetValue<T>()
        {
            try
            {
                if (Type == OptionType.Bool && typeof(T) == typeof(bool))
                {
                    return (T)(object)Convert.ToBoolean(Value);
                }
                else if (Type == OptionType.Int32 && typeof(T) == typeof(int))
                {
                    return (T)(object)Convert.ToInt32(Value);
                }
                else if (Type == OptionType.Int64 && typeof(T) == typeof(long))
                {
                    return (T)(object)Convert.ToInt64(Value);
                }
                else if (Type == OptionType.Float && typeof(T) == typeof(float))
                {
                    return (T)(object)Convert.ToSingle(Value);
                }
                else if (Type == OptionType.String && typeof(T) == typeof(string))
                {
                    return (T)(object)Value;
                }

                throw new InvalidOperationException($"The Type {Type} is not compatible with {typeof(T).Name}.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to convert value '{Value}' to {typeof(T).Name}.", ex);
            }
        }

        public static GeneralOptionDto FromGeneralOption(GeneralOption generalOption)
        {
            return new GeneralOptionDto
            {
                Name = generalOption.Name,
                Type = generalOption.Type,
                Value = generalOption.Value
            };
        }
    }
}
