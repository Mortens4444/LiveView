using Database.Interfaces;
using Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Services
{
    public static class ServiceProviderFactoryHelper
    {
        public static void RegisterRepositories(IServiceCollection services)
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
            services.AddScoped<IIOPortRepository, IOPortRepository>();
            services.AddScoped<IIOPortsLogRepository, IOPortsLogRepository>();
            services.AddScoped<IIOPortsRuleRepository, IOPortsRuleRepository>();
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
            services.AddScoped<IServerRepository, ServerRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<ITemplateProcessRepository, TemplateProcessRepository>();
            services.AddScoped<IUserEventRepository, UserEventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUsersInGroupsRepository, UsersInGroupsRepository>();
            services.AddScoped<IVideoSourceRepository, VideoSourceRepository>();
        }
    }
}
