using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TennisPlayers.Application.Abstractions;
using TennisPlayers.Application.Features.RetrievePlayers;

namespace TennisPlayers.Controllers.RetrievePlayers
{
    public sealed class RetrievePlayersController(ITennisPlayersModule tennisPlayersModule) : ApiController(tennisPlayersModule)
    {
        /// <summary>
        /// Retrieves tennis players
        /// </summary>
        /// <returns>All tennis players</returns>
        [HttpGet("", Name = "GetPlayers")]
        [SwaggerOperation(Tags = new string[] { "Players" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrieves Players of tennis players", typeof(object))]
        public async Task<IActionResult> RetrievPlayersAsync()
        {
            var players = await Sender.ExecuteQueryAsync(new RetrievePlayersQuery());
            return Ok(players);
        }
    }
}