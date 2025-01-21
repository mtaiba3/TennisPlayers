using TennisPlayers.Application.Abstractions.Messaging;
using TennisPlayers.Domain;

namespace TennisPlayers.Application.Features.RetrievePlayers;

public class RetrievePlayersQueryHandler(ITennisPlayersRepository tennisPlayersRepository) : IQueryHandler<RetrievePlayersQuery, Dictionary<string, IOrderedEnumerable<SimplePlayerDto>?>?>
{
    public async Task<Dictionary<string, IOrderedEnumerable<SimplePlayerDto>?>?> Handle(RetrievePlayersQuery request, CancellationToken cancellationToken)
    {
        var players = await tennisPlayersRepository.RetrieveAsync();

        if (players == null)
        {
            return null;
        }

        var orderedData = players.GroupBy(d => d.Sex)
                                 .ToDictionary(g => g.Key, 
                                 g => g.Select(d => new SimplePlayerDto(d.Id, d.ShortName, d.Data.Rank))
                                        .OrderBy(f => f.Rank));

        return orderedData;
    }

}

public record RetrievePlayersQuery() : IQuery<Dictionary<string, IOrderedEnumerable<SimplePlayerDto>?>?>;

public sealed record SimplePlayerDto(int Id,
                          string Name,
                          int Rank);
