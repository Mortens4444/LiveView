using System;
using System.Reflection;

namespace LiveView.Services
{
    public static class ShallowCopyHelper
    {
        public static T ShallowCopy<T>(T source) where T : new()
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var copy = new T();
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var value = field.GetValue(source);
                field.SetValue(copy, value);
            }

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    var value = property.GetValue(source);
                    property.SetValue(copy, value);
                }
            }

            return copy;
        }
    }
}
