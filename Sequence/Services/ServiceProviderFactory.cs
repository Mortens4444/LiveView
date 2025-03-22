using Database.Services;
using LiveView.Core.Services;
using LiveView.Core.Services.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Sequence.Services
{
    public static class ServiceProviderFactory
    {
        public static ServiceProvider Create()
        {
            var services = new ServiceCollection();

            SingletonServiceProviderFactoryHelper.RegisterSingletonServices(services);
            ServiceProviderFactoryHelper.RegisterRepositories(services);
            LogServiceProviderFactoryHelper.RegisterLogServices(services);

            return services.BuildServiceProvider();
        }
    }
}
