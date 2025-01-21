using MediatR;

namespace TennisPlayers.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand;
