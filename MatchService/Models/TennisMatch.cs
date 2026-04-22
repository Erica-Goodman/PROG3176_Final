namespace MatchService.Models;

public class TennisMatch
{
    public int Id { get; set; }
    public List<int> Players { get; set; }
    public string? Score { get; set; }
}