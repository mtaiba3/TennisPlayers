using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TennisPlayers.Application.Abstractions;
using TennisPlayers.Application.Features.RetrievePlayerById;
using TennisPlayers.Controllers;

namespace TennisPlayerById.Controllers.RetrievePlayerById
{
    public sealed class RetrievePlayerByIdController(ITennisPlayersModule tennisPlayersModule) : ApiController(tennisPlayersModule)
    {
        /// <summary>
        /// Retrieves tennis Player By Id
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>All informations of a tennis Player By Id</returns>
        [HttpGet("/{playerId:int}", Name = "GetPlayerById")]
        [SwaggerOperation(Tags = new string[] { "Players" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrieves tennis player By Id", typeof(object))]
        public async Task<IActionResult> RetrievPlayerByIdAsync(int playerId)
        {
            var playerById = await Sender.ExecuteQueryAsync(new RetrievePlayerByIdQuery(playerId));
            return Ok(playerById);
        }
    }
}