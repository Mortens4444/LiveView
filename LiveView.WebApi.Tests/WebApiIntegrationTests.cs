using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace LiveView.WebApi.Tests
{
    internal class WebApiIntegrationTests : WebBaseTests
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

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
                    yield return new TestCaseData(route, dtoType).SetName($"Api_{resource}");
                }
            }
        }
    }
}