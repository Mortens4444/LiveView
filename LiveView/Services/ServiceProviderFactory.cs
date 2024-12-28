using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Forms;
using LiveView.Models.Dependencies;
using LiveView.Presenters;
using LiveView.Services.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Services
{
    public static class ServiceProviderFactory
    {
        public static ServiceProvider Create()
        {
            var services = new ServiceCollection();

            RegisterSingletons(services);
            RegisterRepositories(services);
            RegisterPresenters(services);
            RegisterForms(services);
            RegisterPresenterDependencies(services);

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
                builder.Services.AddSingleton<ILoggerProvider>(sp => new LogRepositoryLoggerProvider(
                    sp.GetRequiredService<PermissionManager>(),
                    sp.GetRequiredService<ILogRepository<LogEntry>>()
                ));
            });
            return services.BuildServiceProvider();
        }

        private static void RegisterPresenterDependencies(ServiceCollection services)
        {
            services.AddTransient<AddGridPresenterDependencies>();
            //services.AddTransient<BasePresenterDependencies>();
        }

        private static void RegisterPresenters(ServiceCollection services)
        {
            services.AddTransient<AddCamerasPresenter>();
            services.AddTransient<AddDatabaseServerPresenter>();
            services.AddTransient<AddGridPresenter>();
            services.AddTransient<AddGroupPresenter>();
            services.AddTransient<AddUserPresenter>();
            services.AddTransient<AddVideoServerPresenter>();
            services.AddTransient<AutoCreateWizardPresenter>();
            services.AddTransient<BarcodeReadingsPresenter>();
            services.AddTransient<BasePresenter>();
            services.AddTransient<CameraMotionOptionsPresenter>();
            services.AddTransient<CameraPropertiesPresenter>();
            services.AddTransient<ControlCenterPresenter>();
            services.AddTransient<DisplayPropertiesPresenter>();
            services.AddTransient<DisplaySettingsPresenter>();
            services.AddTransient<EnterPassPresenter>();
            services.AddTransient<GeneralOptionsPresenter>();
            services.AddTransient<GridManagerPresenter>();
            services.AddTransient<IOPortEditorPresenter>();
            services.AddTransient<IOPortSettingsPresenter>();
            services.AddTransient<LicenseFormPresenter>();
            services.AddTransient<LoginFormPresenter>();
            services.AddTransient<LogViewerPresenter>();
            services.AddTransient<MainPresenter>();
            services.AddTransient<MapCreatorPresenter>();
            services.AddTransient<PersonalOptionsPresenter>();
            services.AddTransient<ProfilePresenter>();
            services.AddTransient<SequentialChainsPresenter>();
            services.AddTransient<ServerAndCameraManagementPresenter>();
            services.AddTransient<ServerAndCameraPropertiesPresenter>();
            services.AddTransient<SyncronViewPresenter>();
            services.AddTransient<TemplatesPresenter>();
            services.AddTransient<UserAndGroupManagementPresenter>();
        }

        private static void RegisterSingletons(ServiceCollection services)
        {
            services.AddSingleton<FormFactory>();
            services.AddSingleton<PermissionManager>();
            services.AddSingleton<DisplayManager>();
        }

        private static void RegisterRepositories(ServiceCollection services)
        {
            services.AddSingleton(typeof(ICameraRepository<>), typeof(CameraRepository<>));
            services.AddSingleton(typeof(IDatabaseServerRepository<>), typeof(DatabaseServerRepository<>));
            services.AddSingleton(typeof(IDisplayRepository<>), typeof(DisplayRepository<>));
            services.AddSingleton(typeof(IGeneralOptionsRepository<>), typeof(GeneralOptionsRepository<>));
            services.AddSingleton(typeof(IGridCameraRepository<>), typeof(GridCameraRepository<>));
            services.AddSingleton(typeof(IGridRepository<>), typeof(GridRepository<>));
            services.AddSingleton(typeof(IGridsInSequencesRepository<>), typeof(GridsInSequencesRepository<>));
            services.AddSingleton(typeof(IGroupRepository<>), typeof(GroupRepository<>));
            services.AddSingleton(typeof(IIOPortRepository<>), typeof(IOPortRepository<>));
            services.AddSingleton(typeof(ILanguageRepository<>), typeof(LanguageRepository<>));
            services.AddSingleton(typeof(ILogRepository<>), typeof(LogRepository<>));
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
            services.AddTransient<CameraMotionSettings>();
            services.AddTransient<CameraProperties>();
            services.AddTransient<ControlCenter>();
            services.AddTransient<DisplaySettings>();
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
