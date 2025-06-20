using Database.Services;
using LiveView.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
ServiceProviderFactoryHelper.RegisterRepositories(builder.Services);
ConverterServiceProviderFactoryHelper.RegisterConverters(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    var assembly = typeof(Program).Assembly;
    var resourceName = "LiveView.WebApi.Pages.Index.html";

    using var stream = assembly.GetManifestResourceStream(resourceName);
    if (stream == null)
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Index.html not found in embedded resources.");
        return;
    }

    using var reader = new StreamReader(stream);
    var html = await reader.ReadToEndAsync();
    await context.Response.WriteAsync(html);
});

if (!DatabaseInitializer.Initialize("LiveViewConnectionString"))
{
    return;
}

app.Run();
