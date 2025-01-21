using TennisPlayers.Application.Abstractions.Messaging;

namespace TennisPlayers.Application.Abstractions;


public interface ITennisPlayersModule
{
    Task ExecuteCommandAsync(ICommand command);
    Task ExecuteNotificationAsync(INotificationRequest notification);
    Task<T> ExecuteQueryAsync<T>(IQuery<T> retrieveQuery);
}
