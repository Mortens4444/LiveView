using Database.Services;
using LiveView.Core.Services;
using LiveView.Core.Services.Logging;
using LiveView.Forms;
using LiveView.Models.Dependencies;
using LiveView.Presenters;
using LiveView.Services.Coloring;
using Microsoft.Extensions.DependencyInjection;

namespace LiveView.Services
{
    public static class ServiceProviderFactory
    {
        public static ServiceProvider Create()
        {
            var services = new ServiceCollection();

            SingletonServiceProviderFactoryHelper.RegisterSingletonServices(services);
            ServiceProviderFactoryHelper.RegisterRepositories(services);
            RegisterPresenters(services);
            RegisterForms(services);
            RegisterPresenterDependencies(services);
            RegisterServices(services);
            LogServiceProviderFactoryHelper.RegisterLogServices(services);

            return services.BuildServiceProvider();
        }

        private static void RegisterServices(ServiceCollection services)
        {
            services.AddTransient<ColorizeControlsService>();
        }

        private static void RegisterPresenterDependencies(ServiceCollection services)
        {
            services.AddTransient<AddCamerasPresenterDependencies>();
            services.AddTransient<AddDatabaseServerPresenterDependencies>();            
            services.AddTransient<AddGridPresenterDependencies>();
            services.AddTransient<AddGroupPresenterDependencies>();
            services.AddTransient<AddUserPresenterDependencies>();
            services.AddTransient<AutoCreateWizardPresenterDependencies>();
            services.AddTransient<BarcodeScanOptionsPresenterDependencies>();
            services.AddTransient<BarcodeScanReadingsPresenterDependencies>();
            services.AddTransient<CameraMotionOptionsPresenterDependencies>();
            services.AddTransient<CameraPropertiesPresenterDependencies>();
            services.AddTransient<ControlCenterPresenterDependencies>();
            services.AddTransient<DisplayPropertiesPresenterDependencies>();
            services.AddTransient<UpgradeFormPresenterDependencies>();
            services.AddTransient<GeneralOptionsPresenterDependencies>();
            services.AddTransient<GridManagerPresenterDependencies>();
            services.AddTransient<IOPortEditorPresenterDependencies>();
            services.AddTransient<IOPortSettingsPresenterDependencies>();
            services.AddTransient<KBD300ASimulatorPresenterDependencies>();
            services.AddTransient<LanguageFileChangedPresenterDependencies>();
            services.AddTransient<LogViewerPresenterDependencies>();
            services.AddTransient<MainPresenterDependencies>();
            services.AddTransient<MapCreatorPresenterDependencies>();
            services.AddTransient<MotionPopupPresenterDependencies>();
            services.AddTransient<MapLoaderDependencies>();
            services.AddTransient<PersonalOptionsPresenterDependencies>();
            services.AddTransient<ProfilePresenterDependencies>();
            services.AddTransient<SearchCameraUrlDependencies>();
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
            services.AddTransient<BarcodeScanReadingsPresenter>();
            services.AddTransient<BasePresenter>();
            services.AddTransient<CameraMotionOptionsPresenter>();
            services.AddTransient<CameraPropertiesPresenter>();
            services.AddTransient<ControlCenterPresenter>();
            services.AddTransient<DisplayPropertiesPresenter>();
            services.AddTransient<DisplaySettingsPresenter>();
            services.AddTransient<UpgradeFormPresenter>();
            services.AddTransient<GeneralOptionsPresenter>();
            services.AddTransient<GridManagerPresenter>();
            services.AddTransient<IOPortEditorPresenter>();
            services.AddTransient<IOPortSettingsPresenter>();
            services.AddTransient<KBD300ASimulatorPresenter>();
            services.AddTransient<LanguageFileChangedPresenter>();
            services.AddTransient<LicenseFormPresenter>();
            services.AddTransient<LoginFormPresenter>();
            services.AddTransient<LogViewerPresenter>();
            services.AddTransient<MainPresenter>();
            services.AddTransient<MapCreatorPresenter>();
            services.AddTransient<MotionPopupPresenter>();
            services.AddTransient<PersonalOptionsPresenter>();
            services.AddTransient<ProfilePresenter>();
            services.AddTransient<SearchCameraUrlPresenter>();
            services.AddTransient<SequentialChainsPresenter>();
            services.AddTransient<ServerAndCameraManagementPresenter>();
            services.AddTransient<ServerAndCameraPropertiesPresenter>();
            services.AddTransient<SyncronViewPresenter>();
            services.AddTransient<TemplatesPresenter>();
            services.AddTransient<UserAndGroupManagementPresenter>();
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
            services.AddTransient<UpgradeForm>();
            services.AddTransient<GridManager>();
            services.AddTransient<IOPortEditor>();
            services.AddTransient<IOPortSettings>();
            services.AddTransient<KBD300ASimulator>();
            services.AddTransient<LanguageFileChangedForm>();
            services.AddTransient<LicenseForm>();
            services.AddTransient<LoginForm>();
            services.AddTransient<LogViewer>();
            services.AddTransient<MainForm>();
            services.AddTransient<MapCreator>();
            services.AddTransient<MotionPopup>();
            services.AddTransient<PersonalOptionsForm>();
            services.AddTransient<Profile>();
            services.AddTransient<SearchCameraUrlForm>();
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
