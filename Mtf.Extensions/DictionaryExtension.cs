using System;
using System.Collections.Generic;
using System.Linq;

namespace Mtf.Extensions
{
    public static class DictionaryExtension
    {
        public static void AddNotEmpty<TKey, TValue>(this Dictionary<TKey, IEnumerable<TValue>> dictionary, TKey key, IEnumerable<TValue> elements)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (elements != null && elements.Any())
            {
                dictionary[key] = elements;
            }
        }
    }
}
