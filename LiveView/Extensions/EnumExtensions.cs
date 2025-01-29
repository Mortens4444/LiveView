using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LiveView.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute != null ? attribute.Description : value.ToString();
        }

        public static TEnum GetFromDescription<TEnum>(string formattedString) where TEnum : Enum
        {
            var name = formattedString.Split('(')[0].Trim();
            if (Enum.IsDefined(typeof(TEnum), name))
            {
                return (TEnum)Enum.Parse(typeof(TEnum), name);
            }

            throw new ArgumentException($"No enum value found for '{name}' in {typeof(TEnum).Name}");
        }

        public static List<object> GetIndividualValues(Type enumType)
        {
            return Enum.GetValues(enumType)
                       .Cast<object>()
                       .Where(value => IsPowerOfTwo(Convert.ToInt64(value)))
                       .ToList();
        }

        private static bool IsPowerOfTwo(long value) => value != 0 && (value & (value - 1)) == 0;
    }
}
