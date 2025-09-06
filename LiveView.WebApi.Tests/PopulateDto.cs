using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LiveView.WebApi.Tests
{
    internal static class PopulateDto
    {
        public static void WithDefaults(object dto, Type dtoType)
        {
            WithDefaultsInternal(dto, dtoType, 0, 2);
        }

        private static void WithDefaultsInternal(object dto, Type dtoType, int depth, int maxDepth)
        {
            if (dto == null || dtoType == null) return;
            if (depth > maxDepth) return;

            var props = dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite && p.GetIndexParameters().Length == 0);

            foreach (var p in props)
            {
                if (String.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var t = p.PropertyType;

                var currentVal = p.GetValue(dto);
                if (currentVal != null)
                {
                    if (t == typeof(string) && (string)currentVal == String.Empty)
                    {
                    }
                    if (t == typeof(DateTime))
                    {
                        p.SetValue(dto, DateTime.UtcNow);
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (String.Equals(p.Name, "Image", StringComparison.OrdinalIgnoreCase))
                {
                    if (t == typeof(byte[]))
                    {
                        p.SetValue(dto, new byte[] { 0x1, 0x2, 0x3 });
                        continue;
                    }

                    if (t == typeof(string))
                    {
                        p.SetValue(dto, Convert.ToBase64String(new byte[] { 0x1, 0x2, 0x3 }));
                        continue;
                    }
                }

                var isRequired = p.GetCustomAttributes(typeof(RequiredAttribute), inherit: true).Length != 0;

                if (t == typeof(string))
                {
                    p.SetValue(dto, "test");
                    continue;
                }

                if (t == typeof(Guid))
                {
                    p.SetValue(dto, Guid.NewGuid());
                    continue;
                }

                if (t == typeof(int) || t == typeof(long) || t == typeof(short) ||
                    t == typeof(byte) || t == typeof(uint) || t == typeof(ulong) ||
                    t == typeof(ushort) || t == typeof(sbyte))
                {
                    var val = Convert.ChangeType(1, t, CultureInfo.InvariantCulture);
                    p.SetValue(dto, val);
                    continue;
                }

                if (t == typeof(bool))
                {
                    p.SetValue(dto, true);
                    continue;
                }

                if (t == typeof(DateTime))
                {
                    p.SetValue(dto, DateTime.UtcNow);
                    continue;
                }

                if (t.IsEnum)
                {
                    var enumValues = Enum.GetValues(t);
                    if (enumValues.Length > 0)
                    {
                        p.SetValue(dto, enumValues.GetValue(0));
                    }
                    continue;
                }

                var underlying = Nullable.GetUnderlyingType(t);
                if (underlying != null)
                {
                    if (underlying == typeof(int) || underlying == typeof(long) || underlying == typeof(short) ||
                        underlying == typeof(byte))
                    {
                        p.SetValue(dto, Convert.ChangeType(1, underlying, CultureInfo.InvariantCulture));
                        continue;
                    }

                    if (underlying == typeof(bool))
                    {
                        p.SetValue(dto, true);
                        continue;
                    }

                    if (underlying == typeof(DateTime))
                    {
                        p.SetValue(dto, DateTime.UtcNow);
                        continue;
                    }

                    if (underlying.IsEnum)
                    {
                        var enumValues = Enum.GetValues(underlying);
                        if (enumValues.Length > 0)
                        {
                            p.SetValue(dto, enumValues.GetValue(0));
                        }
                        continue;
                    }
                }

                if (t == typeof(byte[]))
                {
                    p.SetValue(dto, new byte[] { 0x1, 0x2, 0x3 });
                    continue;
                }

                if (typeof(IEnumerable).IsAssignableFrom(t) && t != typeof(string))
                {
                    if (t.IsArray)
                    {
                        var elemType = t.GetElementType();
                        var elem = CreateSimpleInstance(elemType, depth, maxDepth);
                        var arr = Array.CreateInstance(elemType, 1);
                        arr.SetValue(elem, 0);
                        p.SetValue(dto, arr);
                        continue;
                    }

                    var interfaces = t.GetInterfaces().Concat(new[] { t });
                    var gen = interfaces
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                        .Select(i => i.GetGenericArguments()[0])
                        .FirstOrDefault();

                    if (gen != null)
                    {
                        var listType = typeof(List<>).MakeGenericType(gen);
                        var list = (IList)Activator.CreateInstance(listType);
                        var elem = CreateSimpleInstance(gen, depth + 1, maxDepth);
                        list.Add(elem);
                        p.SetValue(dto, list);
                        continue;
                    }
                }

                if (t.IsClass)
                {
                    var child = Activator.CreateInstance(t);
                    WithDefaultsInternal(child, t, depth + 1, maxDepth);
                    p.SetValue(dto, child);
                    continue;
                }

                if (isRequired)
                {
                    p.SetValue(dto, "test");
                }
            }
        }

        private static object CreateSimpleInstance(Type t, int depth, int maxDepth)
        {
            if (t == typeof(string))
            {
                return "test";
            }

            if (t == typeof(int) || t == typeof(long) || t == typeof(short) ||
                t == typeof(byte) || t == typeof(uint) || t == typeof(ulong) ||
                t == typeof(ushort) || t == typeof(sbyte))
            {
                return Convert.ChangeType(1, t, CultureInfo.InvariantCulture);
            }

            if (t == typeof(bool))
            {
                return true;
            }

            if (t == typeof(DateTime))
            {
                return DateTime.UtcNow;
            }

            if (t == typeof(Guid))
            {
                return Guid.NewGuid();
            }

            if (t.IsEnum)
            {
                var values = Enum.GetValues(t);
                if (values.Length > 0)
                {
                    return values.GetValue(0);
                }
            }

            if (t.IsArray)
            {
                var elemType = t.GetElementType();
                var arr = Array.CreateInstance(elemType, 0);
                return arr;
            }

            if (typeof(IEnumerable).IsAssignableFrom(t))
            {
                var interfaces = t.GetInterfaces().Concat(new[] { t });
                var gen = interfaces
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    .Select(i => i.GetGenericArguments()[0])
                    .FirstOrDefault();
                if (gen != null)
                {
                    var listType = typeof(List<>).MakeGenericType(gen);
                    var list = (IList)Activator.CreateInstance(listType);
                    var elem = CreateSimpleInstance(gen, depth + 1, maxDepth);
                    list.Add(elem);
                    return list;
                }
            }

            if (t.IsClass && depth < maxDepth)
            {
                var instance = Activator.CreateInstance(t);
                WithDefaultsInternal(instance, t, depth + 1, maxDepth);
                return instance;
            }

            return null;
        }
    }
}
