using Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Mtf.Database;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LiveView.WebApi.Tests
{
    internal class WebApiIntegrationTests
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        private WebApplicationFactory<Program> factory;
        private HttpClient client;

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

        [Test]
        public async Task GetRootReturnsHtmlWithControllerLinks()
        {
            var response = await client.GetAsync(new Uri("/", UriKind.Relative)).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var html = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Assert.That(html, Does.Contain("<h1>LiveView API endpoints</h1>"));
        }

        [TestCaseSource(nameof(ResourcePages))]
        public async Task ___GetResourceHtmlReturnsHtmlPage___(string route, string resource)
        {
            var response = await client.GetAsync(new Uri(route, UriKind.Relative)).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var html = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.That(html, Does.Contain($"<h1>{resource}</h1>"));
        }

        [TestCaseSource(nameof(ApiEndpoints))]
        public async Task ___ApiCallReturnsList___(string uriString, Type dtoType)
        {
            var res = await client.GetAsync(new Uri(uriString, UriKind.Relative)).ConfigureAwait(false);
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var listType = typeof(List<>).MakeGenericType(dtoType);
            var list = (IList)JsonSerializer.Deserialize(json, listType, JsonSerializerOptions);

            Assert.That(list, Is.Not.Null, $"Endpoint {uriString} returned null or invalid JSON for {dtoType.Name}");
            Assert.That(list, Has.Count.GreaterThanOrEqualTo(0));
        }

        private static IEnumerable<Type> GetControllerTypes()
        {
            var asm = typeof(Program).Assembly;
            const string controller = nameof(Controller);
            const string ctrlNamespace = "LiveView.WebApi.Controllers";

            return asm.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == ctrlNamespace && t.Name.EndsWith(controller, StringComparison.Ordinal))
                .OrderBy(t => t.Name);
        }

        private static string GetResourceName(Type ctrl)
        {
            const string controller = nameof(Controller);
            return ctrl.Name.EndsWith(controller, StringComparison.Ordinal)
                ? ctrl.Name[..^controller.Length]
                : ctrl.Name;
        }

        private static Type GetDtoType(Type ctrl)
        {
            var current = ctrl;
            while (current != null)
            {
                var baseType = current.BaseType;
                if (baseType == null)
                {
                    break;
                }

                if (baseType.IsGenericType)
                {
                    var genDef = baseType.GetGenericTypeDefinition();
                    if (genDef.Name.StartsWith("ApiControllerBase", StringComparison.Ordinal))
                    {
                        var args = baseType.GetGenericArguments();
                        if (args.Length > 0)
                        {
                            return args[0];
                        }
                        break;
                    }
                }

                current = baseType;
            }

            return null;
        }

        private static IEnumerable<TestCaseData> ApiEndpoints()
        {
            foreach (var ctrl in GetControllerTypes())
            {
                var resource = GetResourceName(ctrl);
                var dtoType = GetDtoType(ctrl);

                if (dtoType != null)
                {
                    var route = $"/api/{resource.ToLowerInvariant()}";
                    yield return new TestCaseData(route, dtoType).SetName($"Html_{resource}");
                }
            }
        }

        private static IEnumerable<TestCaseData> ResourcePages()
        {
            foreach (var ctrl in GetControllerTypes())
            {
                var resource = GetResourceName(ctrl);
                var route = $"/{resource}.html";

                yield return new TestCaseData(route, resource).SetName($"Api_{resource}");
            }
        }
    }
}