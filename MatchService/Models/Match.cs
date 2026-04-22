namespace MatchService.Models;

public class Match
{
    public int Id { get; set; }
    public List<string>[2] Players { get; set; } = ["", ""];
    public string? Score { get; set; }
}