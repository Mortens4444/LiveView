using System.Collections.Generic;
using System;
using System.Linq;
using Database.Attributes;

namespace Database.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetEnabledValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Where(value => !value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DisabledAttribute), false)
                    .Any());
        }
    }
}
