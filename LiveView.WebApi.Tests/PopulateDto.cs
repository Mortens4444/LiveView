using System;
using System.Linq;
using System.Reflection;

namespace LiveView.WebApi.Tests
{
    internal enum PopulationMode { Default, Update }

    internal static class PopulateDto
    {
        public static void Populate(object dto, PopulationMode mode)
        {
            if (dto == null) return;
            PopulateInternal(dto, dto.GetType(), mode, 0);
        }

        private static void PopulateInternal(object dto, Type dtoType, PopulationMode mode, int depth)
        {
            if (dto == null || depth > 3) return;

            var properties = dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite && !string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase));

            foreach (var prop in properties)
            {
                var value = GenerateValueForType(prop.PropertyType, mode, depth);
                if (value != null)
                {
                    prop.SetValue(dto, value);
                }
            }
        }

        private static object GenerateValueForType(Type type, PopulationMode mode, int depth)
        {
            if (type == typeof(string))
                return mode == PopulationMode.Default ? "test" : "updated test";

            if (type == typeof(int) || type == typeof(long) || type == typeof(short) || type == typeof(byte))
                return Convert.ChangeType(mode == PopulationMode.Default ? 1 : 100, type);

            if (type == typeof(byte[]))
                return mode == PopulationMode.Default ? new byte[] { 1, 2, 3 } : new byte[] { 3, 2, 1 };

            if (type == typeof(bool))
                return mode == PopulationMode.Default;

            if (type == typeof(DateTime))
                return mode == PopulationMode.Default ? DateTime.UtcNow : DateTime.UtcNow.AddDays(1);

            if (type == typeof(Guid))
                return Guid.NewGuid();

            if (type.IsEnum)
            {
                var enumValues = Enum.GetValues(type);
                var index = (mode == PopulationMode.Default || enumValues.Length < 2) ? 0 : 1;
                return enumValues.Length > index ? enumValues.GetValue(index) : null;
            }

            if (type.IsClass)
            {
                var instance = Activator.CreateInstance(type);
                PopulateInternal(instance, type, mode, depth + 1);
                return instance;
            }

            return null;
        }
    }
}
