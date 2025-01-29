using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LiveView.Services
{
    public static class TypeNameFormatter
    {
        public static string ToReadableFormat(string typeName)
        {
            var result = Regex.Replace(typeName, "(?<!^)([A-Z])", " $1");
            var words = result.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].All(Char.IsUpper))
                {
                    continue;
                }

                words[i] = i == 0 ? words[i] : words[i].ToLower();
            }

            return String.Join(" ", words);
        }
    }
}
