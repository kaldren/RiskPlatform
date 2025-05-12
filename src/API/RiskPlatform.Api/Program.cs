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

#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "RiskPlatform API", Version = "v1" });
});

#endregion Swagger

var app = builder.Build();

#region Bots Module
app.MapBotsModuleEndpoints();
#endregion Bots Module

#region Swagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RiskPlatform API V1");
        c.RoutePrefix = "swagger";
    });
}

#endregion Swagger

app.UseHttpsRedirection();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
