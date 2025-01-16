using Database.Interfaces;
using Database.Repositories;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Models.Dependencies;
using LiveView.Presenters;
using LiveView.Services.Coloring;
using LiveView.Services.Logging;
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

            RegisterSingletons(services);
            RegisterRepositories(services);
            RegisterPresenters(services);
            RegisterForms(services);
            RegisterPresenterDependencies(services);
            RegisterServices(services);

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
                builder.Services.AddSingleton<ILoggerProvider>(sp => new LogRepositoryLoggerProvider(
                    sp.GetRequiredService<PermissionManager<Database.Models.User>>(),
                    sp.GetRequiredService<ILogRepository>()
                ));
            });
            return services.BuildServiceProvider();
        }

        private static void RegisterServices(ServiceCollection services)
        {
            services.AddTransient<ColorizeControlsService>();
        }

        private static void RegisterPresenterDependencies(ServiceCollection services)
        {
            services.AddTransient<AddCamerasPresenterDependencies>();
            services.AddTransient<AddGridPresenterDependencies>();
            services.AddTransient<AddGroupPresenterDependencies>();
            services.AddTransient<AddUserPresenterDependencies>();
            services.AddTransient<AutoCreateWizardPresenterDependencies>();
            services.AddTransient<ControlCenterPresenterDependencies>();
            services.AddTransient<DisplayPropertiesPresenterDependencies>();
            services.AddTransient<EnterPassPresenterDependencies>();
            services.AddTransient<GeneralOptionsPresenterDependencies>();
            services.AddTransient<GridManagerPresenterDependencies>();
            services.AddTransient<LanguageFileChangedPresenterDependencies>();
            services.AddTransient<LogViewerPresenterDependencies>();
            services.AddTransient<MainPresenterDependencies>();
            services.AddTransient<MapCreatorPresenterDependencies>();
            services.AddTransient<MapLoaderDependencies>();            
            services.AddTransient<PersonalOptionsPresenterDependencies>();
            services.AddTransient<ProfilePresenterDependencies>();
            services.AddTransient<SequentialChainsPresenterDependencies>();
            services.AddTransient<ServerAndCameraManagementPresenterDependencies>();
            services.AddTransient<ServerAndCameraPropertiesPresenterDependencies>();
            services.AddTransient<SyncronViewPresenterDependencies>();
            services.AddTransient<TemplatesPresenterDependencies>();
            services.AddTransient<UserAndGroupManagementPresenterDependencies>();
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
            services.AddTransient<LanguageFileChangedPresenter>();
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
            services.AddSingleton<PermissionManager<Database.Models.User>>();
            services.AddSingleton<DisplayManager>();
        }

        private static void RegisterRepositories(ServiceCollection services)
        {
            services.AddScoped<ICameraRepository, CameraRepository>();
            services.AddScoped<ICameraRightRepository, CameraRightRepository>();
            services.AddScoped<IDatabaseServerRepository, DatabaseServerRepository>();
            services.AddScoped<IDisplayRepository, DisplayRepository>();
            services.AddScoped<IGeneralOptionsRepository, GeneralOptionsRepository>();
            services.AddScoped<IGridCameraRepository, GridCameraRepository>();
            services.AddScoped<IGridInSequenceRepository, GridInSequenceRepository>();
            services.AddScoped<IGridRepository, GridRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IIOPortRepository, IOPortRepository>();
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
            services.AddTransient<LanguageFileChangedForm>();
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
