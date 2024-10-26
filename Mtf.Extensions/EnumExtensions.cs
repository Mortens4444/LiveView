using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Mtf.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<TValueType>(this TValueType value)
            where TValueType : Enum
        {
            var valueStr = value.ToString();
            var type = value.GetType();
            var memberInfo = type.GetMember(valueStr);

            if (memberInfo == null || memberInfo.Length < 1)
            {
                return value.ToString();
            }

            var descriptionAttribute = (DescriptionAttribute[])memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.FirstOrDefault()?.Description ?? valueStr;
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                var attribute = field.GetCustomAttribute<DescriptionAttribute>();
                if (field != null && attribute != null && attribute.Description == description)
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException($"No enum value found for description '{description}'", nameof(description));
        }

        public static string GetComplexDescription<TValueType>(this TValueType value)
            where TValueType : Enum
        {
            if (value.Equals(Enum.ToObject(typeof(TValueType), 0)))
            {
                return value.GetDescription();
            }

            var descriptions = Enum.GetValues(typeof(TValueType))
                                   .Cast<TValueType>()
                                   .Where(v => value.HasFlag(v) && !v.Equals(Enum.ToObject(typeof(TValueType), 0)))
                                   .Select(v => v.GetDescription())
                                   .ToList();

            return String.Join(", ", descriptions);
        }

        public static bool HasAnyFlag(this Enum value, params Enum[] flags)
        {
            return value == null ? throw new ArgumentNullException(nameof(value)) : flags.Any(value.HasFlag);
        }
    }
}
