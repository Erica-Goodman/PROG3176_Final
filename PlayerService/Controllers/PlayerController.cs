using Microsoft.AspNetCore.Mvc;
using PlayerService.Models;

namespace PlayerService.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private PlayerDbContext _context;
    public PlayerController(PlayerDbContext context)
    {
        _context = context;
    }

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

    [HttpPost(Name = "AddPlayer")]
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