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
            services.AddScoped<IVideoSourceRepository, VideoSourceRepository>();
        }
    }
}
