using CameraForms.Services;
using Database.Services;
using LiveView.Core.Services;
using LiveView.Core.Services.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CameraApp.Services
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider Create()
        {
            var services = new ServiceCollection();

            ServiceProviderFactoryHelper.RegisterRepositories(services);
            SingletonServiceProviderFactoryHelper.RegisterSingletonServices(services);
            LogServiceProviderFactoryHelper.RegisterLogServices(services);
            CameraFormsServiceProviderFactoryHelper.RegisterServices(services);

            return services.BuildServiceProvider();
        }
    }
}
