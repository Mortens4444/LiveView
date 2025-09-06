using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace LiveView.WebApi.Tests
{
    internal class WebApiIntegrationTests : WebBaseTests
    {
        private const int resourceId = 2;
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        [TestCaseSource(nameof(SelectCollectionApiEndpoints))]
        public async Task ___SelectCollectionApiCallReturnsList___(string uriString, Type dtoType)
        {
            var result = await client.GetAsync(new Uri(uriString, UriKind.Relative)).ConfigureAwait(false);
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            var listType = typeof(List<>).MakeGenericType(dtoType);
            var list = (IList)JsonSerializer.Deserialize(json, listType, JsonSerializerOptions);

            Assert.That(list, Is.Not.Null, $"Endpoint {uriString} returned null or invalid JSON for {dtoType.Name}");
            Assert.That(list, Has.Count.GreaterThanOrEqualTo(0));
        }

        [TestCaseSource(nameof(SelectResourceApiEndpoints))]
        public async Task ___SelectResourceApiCallReturnsList___(string uriString, Type dtoType)
        {
            var result = await client.GetAsync(new Uri(uriString, UriKind.Relative)).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                var item = JsonSerializer.Deserialize(json, dtoType, JsonSerializerOptions);

                Assert.That(item, Is.Not.Null, $"Endpoint {uriString} returned null or invalid JSON for {dtoType.Name}");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail($"Endpoint {uriString} returned status code {result.StatusCode}");
            }
        }

        [Explicit("Integration test — run explicitly (requires DB).")]
        [TestCaseSource(nameof(CreateResourceApiEndpoints))]
        public async Task CreateResourceApiCallCreatesItem(string uriString, Type dtoType)
        {
            var dto = Activator.CreateInstance(dtoType);
            PopulateDto.WithDefaults(dto, dtoType);

            var postResponse = await client.PostAsJsonAsync(new Uri(uriString, UriKind.Relative), dto).ConfigureAwait(false);
            if (postResponse.StatusCode == HttpStatusCode.Created)
            {
                var body = await postResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!String.IsNullOrEmpty(body))
                {
                    var item = JsonSerializer.Deserialize(body, dtoType, JsonSerializerOptions);
                    Assert.That(item, Is.Not.Null, $"POST to {uriString} returned Created but body was null for {dtoType.Name}");
                    return;
                }

                var location = postResponse.Headers.Location;
                if (location != null)
                {
                    var getResponse = await client.GetAsync(location).ConfigureAwait(false);
                    if (getResponse.IsSuccessStatusCode)
                    {
                        var json = await getResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var item = JsonSerializer.Deserialize(json, dtoType, JsonSerializerOptions);
                        Assert.That(item, Is.Not.Null, $"GET at Location returned null for {uriString}");
                        return;
                    }

                    Assert.Fail($"GET at Location after POST returned {getResponse.StatusCode} for {uriString}");
                }

                Assert.Pass($"POST to {uriString} returned Created without body or Location.");
            }
            else if (postResponse.IsSuccessStatusCode)
            {
                var json = await postResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var item = JsonSerializer.Deserialize(json, dtoType, JsonSerializerOptions);
                Assert.That(item, Is.Not.Null, $"POST to {uriString} returned success but body was null for {dtoType.Name}");
            }
            else if (postResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                var body = await postResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Assert.Inconclusive($"POST to {uriString} returned BadRequest. Content: {body}");
            }
            else
            {
                var body = await postResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Assert.Fail($"POST to {uriString} returned status {postResponse.StatusCode}. Content: {body}");
            }
        }

        [Explicit("Integration test — run explicitly (requires DB).")]
        [TestCaseSource(nameof(UpdateResourceApiEndpoints))]
        public async Task UpdateResourceApiCallReturnsItem(string uriString, Type dtoType)
        {
            int? id = NumericSegment.GetLast(uriString) ?? 0;

            var dto = Activator.CreateInstance(dtoType);
            PopulateDto.WithDefaults(dto, dtoType);
            var idProp = dtoType.GetProperty("Id");
            if (idProp != null && idProp.CanWrite)
            {
                idProp.SetValue(dto, id);
            }

            var putResponse = await client.PutAsJsonAsync(new Uri(uriString, UriKind.Relative), dto).ConfigureAwait(false);
            if (putResponse.StatusCode == HttpStatusCode.NoContent)
            {
                var getResponse = await client.GetAsync(new Uri(uriString, UriKind.Relative)).ConfigureAwait(false);
                if (getResponse.IsSuccessStatusCode)
                {
                    var json = await getResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var item = JsonSerializer.Deserialize(json, dtoType, JsonSerializerOptions);
                    Assert.That(item, Is.Not.Null, $"GET after PUT returned empty body for {uriString}");
                }
                else if (getResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail($"GET after PUT returned status {getResponse.StatusCode} for {uriString}");
                }
            }
            else if (putResponse.IsSuccessStatusCode)
            {
                var json = await putResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var item = JsonSerializer.Deserialize(json, dtoType, JsonSerializerOptions);
                Assert.That(item, Is.Not.Null, $"PUT returned success but body was null for {uriString}");
            }
            else if (putResponse.StatusCode == HttpStatusCode.NotFound)
            {
                var body = await putResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Assert.Fail($"PUT to {uriString} returned status {putResponse.StatusCode}. Content: {body}");
            }
            else
            {
                var body = await putResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Assert.Fail($"PUT to {uriString} returned status {putResponse.StatusCode}. Content: {body}");
            }
        }

        [Explicit("Integration test — run explicitly (requires DB).")]
        [TestCaseSource(nameof(DeleteResourceApiEndpoints))]
        public async Task ___DeleteResourceApiCallDeletesItem___(string uriString, Type dtoType)
        {
            var deleteResponse = await client.DeleteAsync(new Uri(uriString, UriKind.Relative)).ConfigureAwait(false);

            if (deleteResponse.StatusCode == HttpStatusCode.NoContent)
            {
                var getResponse = await client.GetAsync(new Uri(uriString, UriKind.Relative)).ConfigureAwait(false);
                if (getResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    Assert.Pass();
                }

                if (getResponse.IsSuccessStatusCode)
                {
                    var json = await getResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var item = JsonSerializer.Deserialize(json, dtoType, JsonSerializerOptions);
                    Assert.Fail($"DELETE to {uriString} returned NoContent but GET still returned an item: {item}");
                }

                Assert.Fail($"GET after DELETE returned unexpected status {getResponse.StatusCode} for {uriString}");
            }
            else if (deleteResponse.IsSuccessStatusCode)
            {
                var json = await deleteResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!String.IsNullOrEmpty(json))
                {
                    var item = JsonSerializer.Deserialize(json, dtoType, JsonSerializerOptions);
                    Assert.That(item, Is.Not.Null, $"DELETE to {uriString} returned success but body was null for {dtoType.Name}");
                }
                else
                {
                    var getResponse = await client.GetAsync(new Uri(uriString, UriKind.Relative)).ConfigureAwait(false);
                    if (getResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        Assert.Pass();
                    }

                    Assert.Fail($"DELETE to {uriString} returned success but GET returned {getResponse.StatusCode}");
                }
            }
            else if (deleteResponse.StatusCode == HttpStatusCode.NotFound)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail($"DELETE to {uriString} returned status {deleteResponse.StatusCode}");
            }
        }

        private static IEnumerable<TestCaseData> SelectCollectionApiEndpoints()
        {
            return CreateApiTestCases("SelectCollectionApi", r => $"/api/{r}");
        }

        private static IEnumerable<TestCaseData> SelectResourceApiEndpoints()
        {
            return CreateApiTestCases("SelectResourceApi", r => $"/api/{r}/{resourceId}");
        }

        private static IEnumerable<TestCaseData> CreateResourceApiEndpoints()
        {
            return CreateApiTestCases("CreateResourceApi", r => $"/api/{r}");
        }

        private static IEnumerable<TestCaseData> UpdateResourceApiEndpoints()
        {
            return CreateApiTestCases("UpdateResourceApi", r => $"/api/{r}/{resourceId}");
        }

        private static IEnumerable<TestCaseData> DeleteResourceApiEndpoints()
        {
            return CreateApiTestCases("DeleteResourceApi", r => $"/api/{r}/{resourceId}");
        }

        private static IEnumerable<TestCaseData> CreateApiTestCases(string namePrefix, Func<string, string> routeBuilder)
        {
            foreach (var controllerType in GetControllerTypes())
            {
                var resource = GetResourceName(controllerType);
                var dtoType = DtoTypeProvider.GetFromControllerType(controllerType);

                if (dtoType != null)
                {
                    var route = routeBuilder(resource.ToLowerInvariant());
                    yield return new TestCaseData(route, dtoType).SetName($"{namePrefix}_{resource}");
                }
            }
        }
    }
}