using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveView.WebApi.Tests
{
    internal class HtmlResourceTests : WebBaseTests
    {
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

        private static IEnumerable<TestCaseData> ResourcePages()
        {
            foreach (var ctrl in GetControllerTypes())
            {
                var resource = GetResourceName(ctrl);
                var route = $"/{resource}.html";

                yield return new TestCaseData(route, resource).SetName($"Html_{resource}");
            }
        }
    }
}