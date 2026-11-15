using Database.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;

namespace Database.Tests.Repositories.InMemory
{
    [TestFixture]
    public class InMemoryRegistrationTests
    {
        [Test]
        public void InMemoryRegistration_ProvidesEveryRepositoryThatTheSqlRegistrationProvides()
        {
            var sqlServices = new ServiceCollection();
            var inMemoryServices = new ServiceCollection();

            ServiceProviderFactoryHelper.RegisterSqlRepositories(sqlServices);
            ServiceProviderFactoryHelper.RegisterInMemoryRepositories(inMemoryServices);

            var sqlInterfaces = sqlServices.Select(descriptor => descriptor.ServiceType).OrderBy(type => type.Name).ToList();
            var inMemoryInterfaces = inMemoryServices.Select(descriptor => descriptor.ServiceType).OrderBy(type => type.Name).ToList();
            Assert.That(inMemoryInterfaces, Is.EqualTo(sqlInterfaces));

            using var provider = inMemoryServices.BuildServiceProvider();
            foreach (var serviceType in inMemoryInterfaces)
            {
                Assert.That(provider.GetRequiredService(serviceType), Is.Not.Null, serviceType.Name);
            }
        }
    }
}
