using MediatR;
using TennisPlayers.Application.Abstractions;
using TennisPlayers.Application.Abstractions.Messaging;

namespace TennisPlayers.Infrastructure;

public class TennisPlayersModule(IMediator mediator) : ITennisPlayersModule
{
    public Task ExecuteCommandAsync(ICommand command)
        => mediator.Send(command);

    public Task ExecuteNotificationAsync(INotificationRequest notification)
        => mediator.Publish(notification);

    public Task<T> ExecuteQueryAsync<T>(IQuery<T> retrieveQuery)
        => mediator.Send(retrieveQuery);
}