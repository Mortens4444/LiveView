using System;
using System.Collections.Generic;
using System.Linq;

namespace Mtf.Extensions
{
    public static class TypeExtensions
    {
        public static IList<T> InstantiateSubclassesOfAbstractClass<T>(this Type abstractClass, IEnumerable<Type> allTypes)
            where T : class
        {
            var filteredTypes = allTypes
                .Where(type => type.IsSubclassOf(abstractClass) && !type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null);

            return ConstructResult<T>(filteredTypes);
        }

        public static IList<T> InstantiateSubtypes<T>(this Type targetType, IEnumerable<Type> allTypes)
            where T : class
        {
            var filteredTypes = allTypes
                .Where(type => targetType.IsAssignableFrom(type) && !type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null);

            return ConstructResult<T>(filteredTypes);
        }

        private static List<T> ConstructResult<T>(IEnumerable<Type> filteredTypes) where T : class
        {
            var result = new List<T>();
            foreach (var filteredType in filteredTypes)
            {
                var obj = (T)Activator.CreateInstance(filteredType);
                result.Add(obj);
            }
            return result;
        }
    }
}
