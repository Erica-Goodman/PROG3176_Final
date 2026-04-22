using Microsoft.AspNetCore.Mvc;

namespace PlayerService.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    [HttpGet(Name = "GetAllPlayers")]
    public IEnumerable<Player> GetAllPlayers()
    {
        return null;
    }

    [HttpGet(Name = "GetPlayerById")]
    public Player GetPlayer(int id)
    {
        return null;
    }

    [HttpGet(Name = "AddPlayer")]
    public Player AddPlayer(int id)
    {
        return null;
    }

    [HttpGet(Name = "RemovePlayer")]
    public Player RemovePlayer(int id)
    {
        return null;
    }
}