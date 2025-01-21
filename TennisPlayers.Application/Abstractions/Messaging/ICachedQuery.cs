namespace TennisPlayers.Application.Abstractions.Messaging;

public interface ICachedQuery<out TResponse> : IQuery<TResponse>, ICachedQuery;

public interface ICachedQuery
{
    string CacheKey { get; }

    TimeSpan? Expiration { get; }
}