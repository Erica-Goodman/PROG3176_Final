using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using PlayerService.Models;

namespace PlayerService.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayersController : ControllerBase
{
    private PlayerDbContext _context;
    public PlayersController(PlayerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Player>> GetAllPlayers()
    {
        return _context.Players.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Player> GetPlayer(int id)
    {
        var player = _context.Players.Find(id);
        if (player == null)
        {
            return NotFound();
        }
        return player;
    }

    [HttpPost]
    public ActionResult<Player> AddPlayer(Player newPlayer)
    {
        _context.Players.Add(newPlayer);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetPlayer), new {id = newPlayer.Id}, newPlayer);
    }

    [HttpDelete("{id}")]
    public ActionResult<Player> RemovePlayer(int id)
    {
        var player = _context.Players.Find(id);
        if (player == null)
        {
            return NotFound();
        }
        _context.Players.Remove(player);
        _context.SaveChanges();

        return Ok();
    }
}