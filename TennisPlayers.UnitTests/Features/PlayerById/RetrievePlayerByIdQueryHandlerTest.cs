using TennisPlayers.Application.Features.RetrievePlayerById;
using TennisPlayers.Domain;
using TennisPlayers.UnitTests.Implementations;

namespace TennisPlayers.UnitTests.Features;

public class RetrievePlayerByIdQueryHandlerTest
{
    [Fact]
    public async Task ShouldNotRetrievePlayerByIdNoPlayers()
    {
        var repository = new MockTennisPlayersRepository(null!);

        var query = new RetrievePlayerByIdQuery(65);
        var handler = new RetrievePlayerByIdQueryHandler(repository);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact]
    public async Task ShouldNotRetrievePlayerByIdNoMatch()
    {
        var palyers = new List<PlayerDto>
        {
            new PlayerDto(123, "John", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(321, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(432, "Julia", "Doe", "J.doe", "F", new CountryDto("", "USA"), "", new DataDto(321, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(543, "Jonathan", "Doe", "J.doe", "F", new CountryDto("", "USA"), "", new DataDto(321, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(14, "Judy", "Doe", "J.doe", "F", new CountryDto("", "USA"), "", new DataDto(321, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
        };
        var repository = new MockTennisPlayersRepository(palyers);

        var query = new RetrievePlayerByIdQuery(65);
        var handler = new RetrievePlayerByIdQueryHandler(repository);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact]
    public async Task ShouldRetrievePlayerById()
    {
        var palyers = new List<PlayerDto>
        {
            new PlayerDto(123, "John", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(321, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(432, "Julia", "Doe", "J.doe", "F", new CountryDto("", "USA"), "", new DataDto(321, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(543, "Jonathan", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(321, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
            new PlayerDto(14, "Judy", "Doe", "J.doe", "F", new CountryDto("", "USA"), "", new DataDto(321, 1233, 9453, 189, 32, new[]{1,1,0,1,0})),
        };
        var repository = new MockTennisPlayersRepository(palyers);

        var query = new RetrievePlayerByIdQuery(543);
        var handler = new RetrievePlayerByIdQueryHandler(repository);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(543, result.Id);
        Assert.Equal("Jonathan", result.FirstName);
        Assert.Equal("Doe", result.LastName);
        Assert.Equal("J.doe", result.ShortName);
        Assert.Equal("M", result.Sex);
    }
}
