using Database.Services;
using LiveView.Core.Services;
using LiveView.Core.Services.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LiveView.Agent.Services
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider Create()
        {
            var services = new ServiceCollection();

            SingletonServiceProviderFactoryHelper.RegisterSingletonServices(services);
            ServiceProviderFactoryHelper.RegisterRepositories(services);
            LogServiceProviderFactoryHelper.RegisterLogServices(services);

            return services.BuildServiceProvider();
        }
    }
}
