using Database.Repositories;
using Mtf.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Tests
{
    [TestFixture]
    public class SqlSyntaxTests
    {
        public static IEnumerable<TestCaseData> SqlScripts()
        {
            BaseRepository.CommandTimeout = 600;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";
            BaseRepository.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=LiveView;Integrated Security=True;Encrypt=True;";

            var assembly = typeof(CameraRepository).Assembly;
            var resources = assembly.GetManifestResourceNames()
                .Where(r => r.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Replace($"{BaseRepository.DatabaseScriptsLocation}.", String.Empty).Replace(".sql", String.Empty))
                .ToList();

            foreach (var resource in resources)
            {
                yield return new TestCaseData(resource).SetName(resource);
            }
        }

        [TestCaseSource(nameof(SqlScripts))]
        public void ___TestSqlScripts___(string resource)
        {
            var isValid = BaseRepository.HasValidSyntax(resource, false, out var ex);
            Assert.That(isValid, Is.True, $"SQL script '{resource}' has invalid syntax. {ex?.Message}");
        }
    }
}