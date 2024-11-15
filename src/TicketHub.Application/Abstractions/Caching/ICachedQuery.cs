using TicketHub.Application.Abstractions.Messaging;

namespace TicketHub.Application.Abstractions.Caching;


public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;

public interface ICachedQuery
{
    string CacheKey { get; }

    TimeSpan? Expiration { get; }
}
