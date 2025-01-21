using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TennisPlayers.Application.Abstractions;
using TennisPlayers.Domain;
using TennisPlayers.Infrastructure.Repository;

namespace TennisPlayers.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITennisPlayersRepository, TennisPlayersRepository>();
        services.AddScoped<ITennisPlayersModule, TennisPlayersModule>();

        var applicationAssembly = typeof(Application.Application).Assembly;
        services.AddValidatorsFromAssembly(applicationAssembly);
        services.AddMediatR(x => x.RegisterServicesFromAssembly(applicationAssembly));
    }
}
