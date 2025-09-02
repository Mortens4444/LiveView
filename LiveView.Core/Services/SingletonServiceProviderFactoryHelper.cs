using LiveView.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Permissions.Services;

namespace LiveView.Core.Services
{
    public static class SingletonServiceProviderFactoryHelper
    {
        public static void RegisterSingletonServices(ServiceCollection services)
        {
            services.AddSingleton<FormFactory>();
            services.AddSingleton<PermissionManager<Database.Models.User>>();
            services.AddSingleton<IDisplayManager, DisplayManager>();
        }
    }
}