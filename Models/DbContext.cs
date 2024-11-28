using Microsoft.EntityFrameworkCore;

namespace Players.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Player> Players {get; set;}
    public DbSet<Team> Teams {get; set;}
}