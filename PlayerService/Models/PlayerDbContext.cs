using Microsoft.EntityFrameworkCore;

namespace PlayerService.Models;

// modeled after the Microsoft "Create a controller-based web API" tutorial
public class PlayerDbContext : DbContext
{
    public PlayerDbContext(DbContextOptions<PlayerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; } = null!;
}