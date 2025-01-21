using TennisPlayers.Domain;

namespace TennisPlayers.UnitTests.Implementations
{
    internal class MockTennisPlayersRepository : ITennisPlayersRepository
    {
        private readonly List<PlayerDto> _players = new();

        public MockTennisPlayersRepository(List<PlayerDto> players) 
        {
            _players = players;
        }

        public Task<IEnumerable<PlayerDto>?> RetrieveAsync()
        {
            return Task.FromResult<IEnumerable<PlayerDto>?>(_players);
        }
    }
}
