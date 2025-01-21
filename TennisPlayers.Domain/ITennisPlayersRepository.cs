namespace TennisPlayers.Domain;

public interface ITennisPlayersRepository
{
    Task<IEnumerable<PlayerDto>?> RetrieveAsync();
}