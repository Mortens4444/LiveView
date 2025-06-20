using Database.Services;
using LiveView.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
ServiceProviderFactoryHelper.RegisterRepositories(builder.Services);
ConverterServiceProviderFactoryHelper.RegisterConverters(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "LiveView.WebApi v1");
    options.RoutePrefix = "api-docs";
});
app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/Index.html");
    return Task.CompletedTask;
});

if (!DatabaseInitializer.Initialize("LiveViewConnectionString"))
{
    return;
}

app.Run();
