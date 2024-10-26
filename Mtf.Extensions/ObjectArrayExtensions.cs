using System;
using System.Globalization;
using System.Text;

namespace Mtf.Extensions
{
    public static class ObjectArrayExtensions
    {
        public static string ConvertToString(this object[] elements)
        {
            return elements == null ? String.Empty : elements.ToArrayString(0, elements.Length, '\t');
        }

        public static string ToArrayString(this object[] elements)
        {
            return elements == null ? String.Empty : elements.ToArrayString(0, elements.Length);
        }

        public static string ToArrayString(this object[] elements, int startIndex, int endIndex, char separator = ' ')
        {
            if (elements == null || elements.Length == 0)
            {
                return String.Empty;
            }

            var result = new StringBuilder(elements[startIndex].ConvertToString());
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                result.AppendFormat(CultureInfo.InvariantCulture, $"{separator}{elements[i].ConvertToString()}");
            }
            return result.ToString();
        }
    }
}
