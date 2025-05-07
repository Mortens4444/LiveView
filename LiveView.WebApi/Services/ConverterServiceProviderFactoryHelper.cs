using System.Reflection;

namespace LiveView.WebApi.Services
{
    public class ConverterServiceProviderFactoryHelper
    {
        public static void RegisterConverters(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var converterTypes = assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract &&
                               type.Namespace == "LiveView.WebApi.Converters" &&
                               type.Name.EndsWith("Converter"));

            foreach (var converterType in converterTypes)
            {
                services.AddScoped(converterType);
            }
        }
    }
}
