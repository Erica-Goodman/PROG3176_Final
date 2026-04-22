namespace MatchService.Models;

public class TennisMatch
{
    public int Id { get; set; }
    public List<string>[2] Players { get; set; } = ["", ""];
    public string? Score { get; set; }
}