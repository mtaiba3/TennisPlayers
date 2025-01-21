using TennisPlayers.Application.Abstractions.Messaging;
using TennisPlayers.Domain;

namespace TennisPlayers.Application.Features.RetrieveStatistics;

public class RetrieveStatisticsQueryHandler(ITennisPlayersRepository tennisPlayersRepository) : IQueryHandler<RetrieveStatisticsQuery, PlayersStatistics>
{
    public async Task<PlayersStatistics> Handle(RetrieveStatisticsQuery request, CancellationToken cancellationToken)
    {
        var players = await tennisPlayersRepository.RetrieveAsync();

        if (players == null)
        {
            return null;
        }

        var countryStats = players.GroupBy(p => p.Country.Code).Select(g => new
        {
            Country = g.Key,
            WinRatio = g.Sum(p => p.Data.Last.Count(l => l == 1)) / g.Sum(p => p.Data.Last.Count())
        })
        .OrderByDescending(c => c.WinRatio)
        .FirstOrDefault();

        var averageBmi = players.Average(p => p.Data.Weight / Math.Pow(p.Data.Height / 100, 2));

        var medianHeight = players.Select(p => p.Data.Height).OrderBy(h => h).ToArray();

        double median = (medianHeight.Length % 2 == 0)
            ? (medianHeight[medianHeight.Length / 2 - 1] + medianHeight[medianHeight.Length / 2]) / 2
            : medianHeight[medianHeight.Length / 2];

        return new PlayersStatistics(countryStats.Country, averageBmi, median);
    }
}

public record RetrieveStatisticsQuery() : IQuery<PlayersStatistics>;

public sealed record PlayersStatistics(string MostWinsCountry,
                          double MeanBMI,
                          double MedianeHeight);
