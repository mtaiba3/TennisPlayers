using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Abstractions;

namespace TennisPlayers.Controllers;

[ApiController]
[Route("tennis/players")]
public abstract class ApiController(ITennisPlayersModule wishlistModule) : ControllerBase
{
    protected readonly ITennisPlayersModule Sender = wishlistModule;
}