using System;
using System.Reflection;
using System.Text;

namespace LiveView.Services
{
    public static class ResourceHelper
    {
        private static readonly char[] lineSeparators = new[] { '\r', '\n' };

        public static string[] ReadEmbeddedResourceByLines(string resourceName)
        {
            return ReadEmbeddedResourceByLines(resourceName, Assembly.GetExecutingAssembly(), Encoding.UTF8);
        }

        public static string[] ReadEmbeddedResourceByLines(string resourceName, Assembly assembly, Encoding encoding)
        {
            var content = Mtf.Database.Services.ResourceHelper.ReadEmbeddedResource(resourceName, assembly, encoding);
            return content.Split(lineSeparators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
