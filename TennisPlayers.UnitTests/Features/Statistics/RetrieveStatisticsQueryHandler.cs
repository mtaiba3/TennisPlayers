using TennisPlayers.Application.Features.RetrieveStatistics;
using TennisPlayers.Domain;
using TennisPlayers.UnitTests.Implementations;

namespace TennisPlayers.UnitTests.Features;

public class RetrieveStatisticsQueryHandlerTest
{
    [Fact]
    public async Task ShouldNotRetrieveStatisticsNoPlayers()
    {
        var repository = new MockTennisPlayersRepository(null!);

        var query = new RetrieveStatisticsQuery();
        var handler = new RetrieveStatisticsQueryHandler(repository);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact]
    public async Task ShouldRetrieveStatistics()
    {
        var palyers = new List<PlayerDto>
        {
            new PlayerDto(123, "John", "Doe", "J.doe", "M", new CountryDto("", "USA"), "", new DataDto(5, 6000, 5656, 187, 32, new[]{0,0,0,1,0})),
            new PlayerDto(432, "Julia", "Doe", "J.doe", "F", new CountryDto("", "SRB"), "", new DataDto(6, 5000, 4343, 189, 32, new[]{1,1,1,1,0})),
            new PlayerDto(543, "Jonathan", "Doe", "J.doe", "M", new CountryDto("", "TUN"), "", new DataDto(1, 3567, 195, 189, 32, new[]{1,1,1,1,0})),
            new PlayerDto(43, "Judy", "Doe", "J.doe", "F", new CountryDto("", "TUN"), "", new DataDto(2, 9000, 7654, 167, 32, new[]{1,1,0,1,1})),
            new PlayerDto(32, "Judy", "Doe", "J.doe", "F", new CountryDto("", "FRA"), "", new DataDto(7, 4000, 8544, 145, 32, new[]{0,0,0,1,0})),
            new PlayerDto(67, "Judy", "Doe", "J.doe", "F", new CountryDto("", "ALG"), "", new DataDto(3, 8000, 7334, 188, 32, new[]{0,1,0,1,0})),
            new PlayerDto(987, "Judy", "Doe", "J.doe", "F", new CountryDto("", "GER"), "", new DataDto(9, 2000, 2345, 176, 32, new[]{1,0,0,1,0})),
            new PlayerDto(1, "Judy", "Doe", "J.doe", "F", new CountryDto("", "GER"), "", new DataDto(8, 3000, 5678, 177, 32, new[]{1,1,0,1,1})),
            new PlayerDto(56, "Judy", "Doe", "J.doe", "F", new CountryDto("", "SRB"), "", new DataDto(10, 1000, 2344, 166, 32, new[]{1,1,0,0,1})),
            new PlayerDto(77, "Judy", "Doe", "J.doe", "F", new CountryDto("", "ALG"), "", new DataDto(4, 7000, 6576, 175, 32, new[]{1,1,0,1,1})),

        };
        var repository = new MockTennisPlayersRepository(palyers);

        var query = new RetrieveStatisticsQuery();
        var handler = new RetrieveStatisticsQueryHandler(repository);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal("TUN", result.MostWinsCountry);
        Assert.Equal(5066.9, result.MeanBMI);
        Assert.Equal(176, result.MedianeHeight);
    }
}
