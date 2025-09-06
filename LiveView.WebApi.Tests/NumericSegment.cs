using System;

namespace LiveView.WebApi.Tests
{
    internal static class NumericSegment
    {
        internal static readonly char[] separator = new[] { '/' };

        public static int? GetLast(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return null;
            }

            var qIndex = path.IndexOf('?', StringComparison.Ordinal);
            if (qIndex >= 0)
            {
                path = path[..qIndex];
            }

            var parts = path.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                return null;
            }

            for (var i = parts.Length - 1; i >= 0; i--)
            {
                var seg = parts[i];
                if (Int32.TryParse(seg, out var id))
                {
                    return id;
                }
            }

            return null;
        }
    }
}
