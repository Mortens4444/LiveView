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
        private static string connectionString;

        [TestCaseSource(nameof(SqlScripts))]
        public void ___TestSqlScripts___(string resource)
        {
            var isValid = new Mtf.Database.BaseRepository(connectionString).HasValidSyntax(resource, false, out var ex);
            Assert.That(isValid, Is.True, $"SQL script '{resource}' has invalid syntax. {ex?.Message}");
        }

        private static IEnumerable<TestCaseData> SqlScripts()
        {
            Mtf.Database.BaseRepository.CommandTimeout = 600;
            Mtf.Database.BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            Mtf.Database.BaseRepository.DatabaseScriptsLocation = "Database.Scripts";
            connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=LiveView;Integrated Security=True;Encrypt=True;";

            var startPattern = $"{Mtf.Database.BaseRepository.DatabaseScriptsLocation}.";
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