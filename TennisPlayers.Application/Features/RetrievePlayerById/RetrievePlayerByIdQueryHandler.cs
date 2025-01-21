using TennisPlayers.Application.Abstractions.Messaging;
using TennisPlayers.Domain;

namespace TennisPlayers.Application.Features.RetrievePlayerById;

public class RetrievePlayerByIdQueryHandler(ITennisPlayersRepository tennisPlayersRepository) : IQueryHandler<RetrievePlayerByIdQuery, PlayerDto?>
{
    public async Task<PlayerDto?> Handle(RetrievePlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var players = await tennisPlayersRepository.RetrieveAsync();

        if (players == null)
        {
            return null;
        }

        var player = players.FirstOrDefault(p => p.Id == request.PlayerId);
        if (player == null)
        {
            return null;
        }

        return player;
    }
}

public record RetrievePlayerByIdQuery(int PlayerId) : IQuery<PlayerDto?>;
