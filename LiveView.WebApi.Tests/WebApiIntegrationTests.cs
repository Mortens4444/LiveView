using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace LiveView.WebApi.Tests
{
    internal class WebApiIntegrationTests : WebBaseTests
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        [Explicit("Integration test — run explicitly (requires DB).")]
        [TestCaseSource(nameof(CrudEndpoints))]
        public async Task ___FullCrudCycleShouldSucceed___(string createUri, Type dtoType)
        {
            string resourceUri = null;

            try
            {
                var createDto = Activator.CreateInstance(dtoType);
                PopulateDto.Populate(createDto, PopulationMode.Default);

                var createResponse = await client.PostAsJsonAsync(createUri, createDto).ConfigureAwait(false);
                Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "The POST request should have returned with 201 Created status.");

                var createdItem = await createResponse.Content.ReadFromJsonAsync(dtoType, JsonSerializerOptions).ConfigureAwait(false);
                var idProperty = dtoType.GetProperty("Id");
                Assert.That(idProperty, Is.Not.Null, "The DTO must have an 'Id' attribute.");

                var newId = idProperty.GetValue(createdItem);
                Assert.That(newId, Is.Not.Null, "The created item 'Id' cannot be null.");
                resourceUri = $"{createUri}/{newId}";

                PopulateDto.Populate(createdItem, PopulationMode.Update);

                var updateResponse = await client.PutAsJsonAsync(resourceUri, createdItem).ConfigureAwait(false);
                updateResponse.EnsureSuccessStatusCode();

                var updatedItem = await client.GetFromJsonAsync(resourceUri, dtoType, JsonSerializerOptions).ConfigureAwait(false);
                Assert.That(updatedItem, Is.Not.Null);
            }
            finally
            {
                if (resourceUri != null)
                {
                    var deleteResponse = await client.DeleteAsync(resourceUri).ConfigureAwait(false);
                    if (deleteResponse.StatusCode != HttpStatusCode.NotFound)
                    {
                        deleteResponse.EnsureSuccessStatusCode();
                    }

                    var getResponse = await client.GetAsync(resourceUri).ConfigureAwait(false);
                    Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "The resource must return with 404 Not Found status after deletion.");
                }
            }
        }

        private static IEnumerable<TestCaseData> CrudEndpoints()
        {
            foreach (var controllerType in GetControllerTypes())
            {
                var resource = GetResourceName(controllerType);
                var dtoType = DtoTypeProvider.GetFromControllerType(controllerType);
                if (dtoType != null)
                {
                    var createUri = $"/api/{resource.ToLowerInvariant()}";
                    yield return new TestCaseData(createUri, dtoType).SetName($"CrudCycle_{resource}");
                }
            }
        }
    }
}