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
        return null;
    }

    [HttpGet("{id}")]
    public ActionResult<TennisMatch> GetMatch(int id)
    {
        return null;
    }

    [HttpPost]
    public ActionResult<Player> CreateMatch(TennisMatch newMatch)
    {
        return null;
    }

    [HttpDelete("{id}")]
    public ActionResult<TennisMatch> DeleteMatch(int id)
    {
        return null;
    }
}