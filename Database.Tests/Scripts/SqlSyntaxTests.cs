using Database.Repositories;
using Mtf.Database;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Database.Tests.Scripts
{
    [TestFixture]
    public class SqlSyntaxTests
    {
        [TestCaseSource(nameof(SqlScripts))]
        public void ___TestSqlScripts___(string resource)
        {
            var isValid = BaseRepository.HasValidSyntax(resource, false, out var ex);
            Assert.That(isValid, Is.True, $"SQL script '{resource}' has invalid syntax. {ex?.Message}");
        }

        private static IEnumerable<TestCaseData> SqlScripts()
        {
            BaseRepository.CommandTimeout = 600;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";
            BaseRepository.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=LiveView;Integrated Security=True;Encrypt=True;";

            var startPattern = $"{BaseRepository.DatabaseScriptsLocation}.";
            var assembly = typeof(CameraRepository).Assembly;
            var pattern = $"^{Regex.Escape(startPattern)}(.+?)\\.sql$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            var resources = assembly.GetManifestResourceNames()
                .Select(r => regex.Match(r))
                .Where(m => m.Success)
                .Select(m => m.Groups[1].Value)
                .ToList();

            foreach (var resource in resources)
            {
                yield return new TestCaseData(resource).SetName(resource);
            }
        }
    }
}