using Database.Interfaces;
using Database.Repositories;
using LiveView.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Services
{
    public static class ServiceProviderFactory
    {
        public static ServiceProvider Create()
        {
            var services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
            });
            
            RegisterSingletons(services);
            RegisterRepositories(services);
            RegisterForms(services);

            return services.BuildServiceProvider();
        }

        private static void RegisterSingletons(ServiceCollection services)
        {
            services.AddSingleton<FormFactory>();
            services.AddSingleton<PermissionManager>();
        }

        private static void RegisterRepositories(ServiceCollection services)
        {
            services.AddSingleton(typeof(ICameraRepository<>), typeof(CameraRepository<>));
            services.AddSingleton(typeof(IDatabaseServerRepository<>), typeof(DatabaseServerRepository<>));
            services.AddSingleton(typeof(IDisplayRepository<>), typeof(DisplayRepository<>));
            services.AddSingleton(typeof(IGeneralOptionsRepository<>), typeof(GeneralOptionsRepository<>));
            services.AddSingleton(typeof(IGridCameraListRepository<>), typeof(GridCameraListRepository<>));
            services.AddSingleton(typeof(IGridRepository<>), typeof(GridRepository<>));
            services.AddSingleton(typeof(IGridsInSequencesRepository<>), typeof(GridsInSequencesRepository<>));
            services.AddSingleton(typeof(IGroupRepository<>), typeof(GroupRepository<>));
            services.AddSingleton(typeof(IIOPortRepository<>), typeof(IOPortRepository<>));
            services.AddSingleton(typeof(ILanguageRepository<>), typeof(LanguageRepository<>));
            services.AddSingleton(typeof(IMapObjectRepository<>), typeof(MapObjectRepository<>));
            services.AddSingleton(typeof(IMapRepository<>), typeof(MapRepository<>));
            services.AddSingleton(typeof(IPersonalOptionsRepository<>), typeof(PersonalOptionsRepository<>));
            services.AddSingleton(typeof(ISequenceRepository<>), typeof(SequenceRepository<>));
            services.AddSingleton(typeof(IServerRepository<>), typeof(ServerRepository<>));
            services.AddSingleton(typeof(ITemplateRepository<>), typeof(TemplateRepository<>));
            services.AddSingleton(typeof(IUserRepository<>), typeof(UserRepository<>));
            services.AddSingleton(typeof(IUsersInGroupsRepository<>), typeof(UsersInGroupsRepository<>));
        }

        private static void RegisterForms(ServiceCollection services)
        {
            services.AddTransient<AddCameras>();
            services.AddTransient<AddDatabaseServer>();
            services.AddTransient<AddGrid>();
            services.AddTransient<AddGroup>();
            services.AddTransient<AddUser>();
            services.AddTransient<AddVideoServer>();
            services.AddTransient<AutoCreateWizard>();
            services.AddTransient<BarcodeReadings>();
            services.AddTransient<CameraMotionOptions>();
            services.AddTransient<CameraProperties>();
            services.AddTransient<ControlCenter>();
            services.AddTransient<DisplayOptions>();
            services.AddTransient<DisplayProperties>();
            services.AddTransient<EnterPass>();
            services.AddTransient<GridManager>();
            services.AddTransient<IOPortEditor>();
            services.AddTransient<IOPortSettings>();
            services.AddTransient<LicenseForm>();
            services.AddTransient<LoginForm>();
            services.AddTransient<LogViewer>();
            services.AddTransient<MainForm>();
            services.AddTransient<MapCreator>();
            services.AddTransient<PersonalOptionsForm>();
            services.AddTransient<Profile>();
            services.AddTransient<SequentialChains>();
            services.AddTransient<ServerAndCameraManagement>();
            services.AddTransient<ServerAndCameraProperties>();
            services.AddTransient<SyncronView>();
            services.AddTransient<GeneralOptionsForm>();
            services.AddTransient<Templates>();
            services.AddTransient<UserAndGroupManagement>();
        }
    }
}
