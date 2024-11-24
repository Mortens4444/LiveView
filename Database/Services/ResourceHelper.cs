using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Database.Services
{
    public static class ResourceHelper
    {
        private static readonly char[] lineSeparators = new[] { '\r', '\n' };

        public static string GetDbScript(string scriptName)
        {
            return ReadEmbeddedResource(String.Concat("VideoSupervisorBasic.Scripts.", scriptName, ".sql"), Encoding.UTF8);
        }

        public static string ReadEmbeddedResource(string resourceName)
        {
            return ReadEmbeddedResource(resourceName, Encoding.UTF8);
        }

        public static string ReadEmbeddedResource(string resourceName, Encoding encoding)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return ReadEmbeddedResource(resourceName, assembly, encoding);
        }

        public static Stream GetEmbeddedResourceStream(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return GetEmbeddedResourceStream(resourceName, assembly);
        }

        public static Stream GetEmbeddedResourceStream(string resourceName, Assembly assembly)
        {
            return assembly == null ? throw new ArgumentNullException(nameof(assembly))
                : assembly.GetManifestResourceStream(resourceName) ?? throw new ArgumentException($"Resource '{resourceName}' not found.", nameof(resourceName));
        }

        public static string ReadEmbeddedResource(string resourceName, Assembly assembly, Encoding encoding)
        {
            using (var stream = GetEmbeddedResourceStream(resourceName, assembly) ?? throw new ArgumentException($"Resource '{resourceName}' not found.", nameof(resourceName)))
            {
                using (var reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string[] ReadEmbeddedResourceByLines(string resourceName)
        {
            return ReadEmbeddedResourceByLines(resourceName, Assembly.GetExecutingAssembly(), Encoding.UTF8);
        }

        public static string[] ReadEmbeddedResourceByLines(string resourceName, Assembly assembly, Encoding encoding)
        {
            var content = ReadEmbeddedResource(resourceName, assembly, encoding);
            return content.Split(lineSeparators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
