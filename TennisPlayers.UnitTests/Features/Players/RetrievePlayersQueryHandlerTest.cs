using TennisPlayers.Application.Features.RetrievePlayers;
using TennisPlayers.Domain;
using TennisPlayers.UnitTests.Implementations;

namespace TennisPlayers.UnitTests.Features;

public class RetrievePlayersQueryHandlerTest
{
    [Fact]
    public async Task ShouldNotRetrievePlayersNoPlayers()
    {
        var repository = new MockTennisPlayersRepository(null!);

        var query = new RetrievePlayersQuery();
        var handler = new RetrievePlayersQueryHandler(repository);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact]
    public async Task ShouldRetrievePlayersMaleAndFemale()
    {
        var palyers = new List<PlayerDto>
        {
            new PlayerDto(123, "John", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(5, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(432, "Julia", "Doe", "J.doe", "F", new CountryDto("", "USA"), "", new DataDto(10, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(543, "Jonathan", "Doe", "J.doe", "F", new CountryDto("", "USA"), "", new DataDto(3, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(14, "Judy", "Doe", "J.doe", "F", new CountryDto("", "USA"), "", new DataDto(7, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
        };
        var repository = new MockTennisPlayersRepository(palyers);

        var query = new RetrievePlayersQuery();
        var handler = new RetrievePlayersQueryHandler(repository);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(3, result["F"].Count());
        Assert.Equal(1, result["M"].Count());
        Assert.Equal(543, result["F"].First().Id);
        Assert.Equal(432, result["F"].Last().Id);
    }

    [Fact]
    public async Task ShouldRetrievePlayersOnlyMales()
    {
        var palyers = new List<PlayerDto>
        {
            new PlayerDto(123, "John", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(10, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(432, "Julia", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(5, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(543, "Jonathan", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(3, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(14, "Judy", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(1, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
        };
        var repository = new MockTennisPlayersRepository(palyers);

        var query = new RetrievePlayersQuery();
        var handler = new RetrievePlayersQueryHandler(repository);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(1, result.Count);
        Assert.False(result.ContainsKey("F"));
        Assert.Equal(4, result["M"].Count());
        Assert.Equal(14, result["M"].First().Id);
        Assert.Equal(123, result["M"].Last().Id);
    }
}
