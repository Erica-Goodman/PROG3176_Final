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
    public ActionResult<TennisMatch> CreateMatch(TennisMatch newMatch)
    {
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

        return Ok();
    }
}