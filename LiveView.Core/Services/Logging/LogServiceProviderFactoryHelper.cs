using Database.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Mtf.Permissions.Services;

namespace LiveView.Core.Services.Logging
{
    public static class LogServiceProviderFactoryHelper
    {
        public static void RegisterLogServices(ServiceCollection services)
        {
#if NET452 || NET462
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
#else
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
                builder.Services.AddSingleton<ILoggerProvider>(sp => new LogRepositoryLoggerProvider(
                    sp.GetRequiredService<PermissionManager<Database.Models.User>>(),
                    sp.GetRequiredService<ILogRepository>()
                ));
            });
#endif
        }
    }
}