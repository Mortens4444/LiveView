using Database.Interfaces;
using Database.Repositories;
using LiveView.Core.Services.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System;

namespace CameraApp.Services
{
    public static class ServiceProviderFactory
    {
        public static ServiceProvider Create()
        {
            var services = new ServiceCollection();

            RegisterSingletons(services);
            RegisterRepositories(services);

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.Services.AddSingleton<ILoggerProvider>(sp => new LogRepositoryLoggerProvider(
                    sp.GetRequiredService<PermissionManager<Database.Models.User>>(),
                    sp.GetRequiredService<ILogRepository>()
                ));
            });
            return services.BuildServiceProvider();
        }

        private static void RegisterSingletons(ServiceCollection services)
        {
            services.AddSingleton<PermissionManager<Database.Models.User>>();
        }

        private static void RegisterRepositories(ServiceCollection services)
        {
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IBarcodeCharChangerRepository, BarcodeCharChangerRepository>();
            services.AddScoped<IBarcodeScanOptionsRepository, BarcodeScanOptionsRepository>();
            services.AddScoped<IBarcodeScanReadingRepository, BarcodeScanReadingRepository>();
            services.AddScoped<ICameraRepository, CameraRepository>();
            services.AddScoped<ICameraRightRepository, CameraRightRepository>();
            services.AddScoped<IDatabaseServerRepository, DatabaseServerRepository>();
            services.AddScoped<IDisplayRepository, DisplayRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IGeneralOptionsRepository, GeneralOptionsRepository>();
            services.AddScoped<IGridCameraRepository, GridCameraRepository>();
            services.AddScoped<IGridInSequenceRepository, GridInSequenceRepository>();
            services.AddScoped<IGridRepository, GridRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IIOPortRepository, IOPortRepository>();
            services.AddScoped<IIOPortsLogRepository, IOPortsLogRepository>();
            services.AddScoped<IIOPortsRuleRepository, IOPortsRuleRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IMapObjectRepository, MapObjectRepository>();
            services.AddScoped<IMapRepository, MapRepository>();
            services.AddScoped<IObjectInMapRepository, ObjectInMapRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IPersonalOptionsRepository, PersonalOptionsRepository>();
            services.AddScoped<IRightRepository, RightRepository>();
            services.AddScoped<ISequenceRepository, SequenceRepository>();
            services.AddScoped<IServerRepository, ServerRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<ITemplateProcessRepository, TemplateProcessRepository>();
            services.AddScoped<IUserEventRepository, UserEventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUsersInGroupsRepository, UsersInGroupsRepository>();
        }
    }
}
