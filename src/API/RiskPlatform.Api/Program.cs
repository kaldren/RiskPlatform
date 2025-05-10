using RiskPlatform.Modules.Bots.API.Endpoints;
using RiskPlatform.Modules.Bots.Application.Extensions;
using RiskPlatform.Modules.Bots.Infrastructure.Configuration;
using RiskPlatform.Modules.Bots.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Bots Module
builder.Services.AddBotsModuleApplicationServices();
builder.Services.Configure<BotsModuleOptions>(
    builder.Configuration.GetSection("Modules:Bots"));
builder.Services.AddBotsModuleInfrastructureServices(builder.Configuration);
#endregion Bots Module

var app = builder.Build();

#region Bots Module
app.MapBotsModuleEndpoints();
#endregion Bots Module

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
