using Database.Services;
using LiveView.WebApi.Converters;
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

app.MapGet("/", context =>
{
    context.Response.Redirect("/openapi/v1.json");
    return Task.CompletedTask;
});

if (!DatabaseInitializer.Initialize("LiveViewConnectionString"))
{
    return;
}

app.Run();
