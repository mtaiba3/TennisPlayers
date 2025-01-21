using MediatR;

namespace TennisPlayers.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>;