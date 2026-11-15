using Database.Interfaces;
using Database.Repositories;
using Database.Repositories.InMemory;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Services
{
    public static class ServiceProviderFactoryHelper
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            if (DatabaseInitializer.IsInMemoryStorage)
            {
                RegisterInMemoryRepositories(services);
            }
            else
            {
                RegisterSqlRepositories(services);
            }
        }

        internal static void RegisterSqlRepositories(IServiceCollection services)
        {
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IBarcodeCharChangerRepository, BarcodeCharChangerRepository>();
            services.AddScoped<IBarcodeScanOptionsRepository, BarcodeScanOptionsRepository>();
            services.AddScoped<IBarcodeScanReadingRepository, BarcodeScanReadingRepository>();
            services.AddScoped<ICameraRepository, CameraRepository>();
            services.AddScoped<ICameraFunctionRepository, CameraFunctionRepository>();
            services.AddScoped<ICameraPermissionRepository, CameraPermissionRepository>();
            services.AddScoped<IDatabaseServerRepository, DatabaseServerRepository>();
            services.AddScoped<IDisplayRepository, DisplayRepository>();
            services.AddScoped<IGeneralOptionsRepository, GeneralOptionsRepository>();
            services.AddScoped<IGridCameraRepository, GridCameraRepository>();
            services.AddScoped<ISequenceGridsRepository, SequenceGridsRepository>();
            services.AddScoped<IGridRepository, GridRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IInputOutputPortRepository, InputOutputPortRepository>();
            services.AddScoped<IInputOutputPortLogRepository, InputOutputPortLogRepository>();
            services.AddScoped<IInputOutputPortRuleRepository, InputOutputPortRuleRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IActionObjectRepository, ActionObjectRepository>();
            services.AddScoped<IMapRepository, MapRepository>();
            services.AddScoped<IMigrationRepository, MigrationRepository>();
            services.AddScoped<IMapActionObjectRepository, MapActionObjectRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IPersonalOptionsRepository, PersonalOptionsRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<ISequenceRepository, SequenceRepository>();
            services.AddScoped<IVideoServerRepository, VideoServerRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<ITemplateProcessRepository, TemplateProcessRepository>();
            services.AddScoped<IUserEventRepository, UserEventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupMembersRepository, GroupMembersRepository>();
            services.AddScoped<IVideoSourceRepository, VideoSourceRepository>();
        }

        internal static void RegisterInMemoryRepositories(IServiceCollection services)
        {
            services.AddScoped<IAgentRepository, InMemoryAgentRepository>();
            services.AddScoped<IBarcodeCharChangerRepository, InMemoryBarcodeCharChangerRepository>();
            services.AddScoped<IBarcodeScanOptionsRepository, InMemoryBarcodeScanOptionsRepository>();
            services.AddScoped<IBarcodeScanReadingRepository, InMemoryBarcodeScanReadingRepository>();
            services.AddScoped<ICameraRepository, InMemoryCameraRepository>();
            services.AddScoped<ICameraFunctionRepository, InMemoryCameraFunctionRepository>();
            services.AddScoped<ICameraPermissionRepository, InMemoryCameraPermissionRepository>();
            services.AddScoped<IDatabaseServerRepository, InMemoryDatabaseServerRepository>();
            services.AddScoped<IDisplayRepository, InMemoryDisplayRepository>();
            services.AddScoped<IGeneralOptionsRepository, InMemoryGeneralOptionsRepository>();
            services.AddScoped<IGridCameraRepository, InMemoryGridCameraRepository>();
            services.AddScoped<ISequenceGridsRepository, InMemorySequenceGridsRepository>();
            services.AddScoped<IGridRepository, InMemoryGridRepository>();
            services.AddScoped<IGroupRepository, InMemoryGroupRepository>();
            services.AddScoped<IInputOutputPortRepository, InMemoryInputOutputPortRepository>();
            services.AddScoped<IInputOutputPortLogRepository, InMemoryInputOutputPortLogRepository>();
            services.AddScoped<IInputOutputPortRuleRepository, InMemoryInputOutputPortRuleRepository>();
            services.AddScoped<ILanguageRepository, InMemoryLanguageRepository>();
            services.AddScoped<ILogRepository, InMemoryLogRepository>();
            services.AddScoped<IActionObjectRepository, InMemoryActionObjectRepository>();
            services.AddScoped<IMapRepository, InMemoryMapRepository>();
            services.AddScoped<IMigrationRepository, InMemoryMigrationRepository>();
            services.AddScoped<IMapActionObjectRepository, InMemoryMapActionObjectRepository>();
            services.AddScoped<IOperationRepository, InMemoryOperationRepository>();
            services.AddScoped<IPersonalOptionsRepository, InMemoryPersonalOptionsRepository>();
            services.AddScoped<IPermissionRepository, InMemoryPermissionRepository>();
            services.AddScoped<ISequenceRepository, InMemorySequenceRepository>();
            services.AddScoped<IVideoServerRepository, InMemoryVideoServerRepository>();
            services.AddScoped<ITemplateRepository, InMemoryTemplateRepository>();
            services.AddScoped<ITemplateProcessRepository, InMemoryTemplateProcessRepository>();
            services.AddScoped<IUserEventRepository, InMemoryUserEventRepository>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IGroupMembersRepository, InMemoryGroupMembersRepository>();
            services.AddScoped<IVideoSourceRepository, InMemoryVideoSourceRepository>();
        }
    }
}
