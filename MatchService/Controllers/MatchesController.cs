using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using MatchService.Models;

namespace MatchService.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchesController : ControllerBase
{
    private MatchDbContext _context;
    public MatchesController(MatchDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TennisMatch>> GetAllMatches()
    {
        return _context.MatchList.ToList();

    }

    [HttpGet("{id}")]
    public ActionResult<TennisMatch> GetMatch(int id)
    {
        var tennisMatch = _context.MatchList.Find(id);
        if (tennisMatch == null)
        {
            return NotFound();
        }
        return tennisMatch;
    }

    [HttpPost]
    public async Task<ActionResult<TennisMatch>> CreateMatch(TennisMatch newMatch)
    {
        var player1id = newMatch.Players[0];
        var player2id = newMatch.Players[1];

        // add validation to check for correct number of players? maybe...
        if((player1id == null || player2id == null) || newMatch.Players[2] != null)
        {
            return BadRequest(new{message = "Requires 2 players per match!"});
        }

        // check if player IDs exist
        using HttpClient client = new HttpClient();
        var player1 = await client.GetAsync($"http://localhost:5209/Players/{player1id}");
        var player2 = await client.GetAsync($"http://localhost:5209/Players/{player2id}");
        if(player1 == null || player2 == null)
        {
            return NotFound(new{message = "Player ID not found."});
        }

        _context.MatchList.Add(newMatch);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMatch), new {id = newMatch.Id}, newMatch);
    }

    [HttpDelete("{id}")]
    public ActionResult<TennisMatch> DeleteMatch(int id)
    {
        var tennisMatch = _context.MatchList.Find(id);
        if (tennisMatch == null)
        {
            return NotFound();
        }
        _context.MatchList.Remove(tennisMatch);
        _context.SaveChanges();

        return Ok(new{message = "Match successfully deleted."});
    }
}