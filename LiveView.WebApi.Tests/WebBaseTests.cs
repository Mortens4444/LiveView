using Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Mtf.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace LiveView.WebApi.Tests
{
    abstract class WebBaseTests
    {
        protected WebApplicationFactory<Program> factory;
        protected HttpClient client;

        [OneTimeSetUp]
        public void SetUp()
        {
            factory = new CustomWebApplicationFactory();
            client = factory.CreateClient();

            BaseRepository.CommandTimeout = 600;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";
            BaseRepository.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=LiveView;Integrated Security=True;Encrypt=True;";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            factory?.Dispose();
            client?.Dispose();
        }
        protected static IEnumerable<Type> GetControllerTypes()
        {
            var asm = typeof(Program).Assembly;
            const string controller = nameof(Controller);
            const string ctrlNamespace = "LiveView.WebApi.Controllers";

            return asm.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == ctrlNamespace && t.Name.EndsWith(controller, StringComparison.Ordinal))
                .OrderBy(t => t.Name);
        }

        protected static string GetResourceName(Type ctrl)
        {
            const string controller = nameof(Controller);
            return ctrl.Name.EndsWith(controller, StringComparison.Ordinal)
                ? ctrl.Name[..^controller.Length]
                : ctrl.Name;
        }
    }
}