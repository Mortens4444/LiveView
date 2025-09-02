using CameraForms.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CameraForms.Services
{
    public static class CameraFormsServiceProviderFactoryHelper
    {
        public static void RegisterServices(ServiceCollection services)
        {
            services.AddSingleton<ICameraRegister, CameraRegister>();
            services.AddSingleton<IDisplayProvider, DisplayProvider>();
        }
    }
}