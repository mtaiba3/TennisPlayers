using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TennisPlayers.Application.Abstractions;
using TennisPlayers.Application.Features.RetrieveStatistics;

namespace TennisPlayers.Controllers.RetrieveStatistics
{
    public sealed class RetrieveStatisticsController (ITennisPlayersModule tennisPlayersModule) : ApiController(tennisPlayersModule)
    {

        /// <summary>
        /// Retrieves statistics of tennis players
        /// </summary>
        /// <returns>country with most wins, IMC of players and the mediane of players size</returns>
        [HttpGet("/statistics", Name = "GetStatistics")]
        [SwaggerOperation(Tags = new string[] { "Statistics" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrieves Statistics of tennis players", typeof(object))]
        public async Task<IActionResult> RetrievStatisticsAsync()
        {
            var Statistics = await Sender.ExecuteQueryAsync(new RetrieveStatisticsQuery());
            return Ok(Statistics);
        }
    }
}