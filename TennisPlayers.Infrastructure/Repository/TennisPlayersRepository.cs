using Newtonsoft.Json;
using TennisPlayers.Domain;

namespace TennisPlayers.Infrastructure.Repository
{
    public class TennisPlayersRepository : ITennisPlayersRepository
    {
        public Task<IEnumerable<PlayerDto>?> RetrieveAsync()
        {
            var dataAccess = new HeadToHeadDataAccess();
            var jsonData = dataAccess.GetEmbeddedJson();
            var players = JsonConvert.DeserializeObject<IEnumerable<PlayerEntity>>(jsonData);

            return Task.FromResult(players.Select
                (p => new PlayerDto(
                    p.Id, 
                    p.FirstName, 
                    p.LastName, 
                    p.ShortName, 
                    p.Sex, 
                    new CountryDto(p.Country.Picture, p.Country.Code), 
                    p.Picture, 
                    new DataDto(p.Data.Rank, p.Data.points, p.Data.Weight, p.Data.Height, p.Data.Age, p.Data.Last))));
        }
    }
}
