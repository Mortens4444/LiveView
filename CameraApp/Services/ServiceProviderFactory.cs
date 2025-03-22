using Database.Services;
using LiveView.Core.Services;
using LiveView.Core.Services.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CameraApp.Services
{
    public static class ServiceProviderFactory
    {
        public static ServiceProvider Create()
        {
            var services = new ServiceCollection();

            ServiceProviderFactoryHelper.RegisterRepositories(services);
            SingletonServiceProviderFactoryHelper.RegisterSingletonServices(services);
            LogServiceProviderFactoryHelper.RegisterLogServices(services);

            return services.BuildServiceProvider();
        }
    }
}
