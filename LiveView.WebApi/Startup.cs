using Database.Services;
using LiveView.WebApi.Services;

namespace LiveView.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceProviderFactoryHelper.RegisterRepositories(services);
            ConverterServiceProviderFactoryHelper.RegisterConverters(services);

            services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "LiveView.WebApi v1");
                options.RoutePrefix = "api-docs";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/", HtmlPageBuilder.RootHtmlPage);
                endpoints.MapGet("/{resource}.html", async (HttpContext ctx, string resource) =>
                {
                    await HtmlPageBuilder.ResourceHtmlPage(ctx, resource);
                });
            });
        }
    }
}
