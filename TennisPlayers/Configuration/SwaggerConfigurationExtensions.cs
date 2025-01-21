using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TennisPlayers.Configuration;

internal static class SwaggerConfigurationExtensions
{
    internal static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(swaggerGenOptions =>
        {
            swaggerGenOptions.EnableAnnotations();
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "TennisPlayers", Version = "v1" });
        });
    }

    internal static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TennisPlayers v1");
            c.RoutePrefix = string.Empty;
        });
    }
}
