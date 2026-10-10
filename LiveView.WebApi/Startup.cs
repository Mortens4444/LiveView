using Database.Services;
using LiveView.Core.Dependencies;
using LiveView.Core.Services;
using LiveView.WebApi.Authorization;
using LiveView.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LiveView.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceProviderFactoryHelper.RegisterRepositories(services);
            ConverterServiceProviderFactoryHelper.RegisterConverters(services);

            services.AddScoped<PermissionSetterDependencies>();
            services.AddScoped<PermissionSetter>();

            var jwtSigningKeyValue = AppConfig.GetString("JwtSigningKey");
            if (string.IsNullOrWhiteSpace(jwtSigningKeyValue) || Encoding.UTF8.GetBytes(jwtSigningKeyValue).Length < 32)
            {
                throw new InvalidOperationException(
                    "The JwtSigningKey environment variable must be set to a value of at least 32 bytes (256 bits) before LiveView.WebApi can start.");
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSigningKeyValue));
            services.AddSingleton(new JwtOptions(signingKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = JwtOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1)
                    };
                });

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<PermissionAuthorizationFilter>();
            });
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
            app.UseAuthentication();
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
