using Microsoft.EntityFrameworkCore;

namespace MatchService.Models;

// modeled after the Microsoft "Create a controller-based web API" tutorial
public class MatchDbContext : DbContext
{
    public MatchDbContext(DbContextOptions<MatchDbContext> options)
        : base(options)
    {
    }

    public DbSet<TennisMatch> MatchList { get; set; } = null!;
}