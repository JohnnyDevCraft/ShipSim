using Microsoft.EntityFrameworkCore;

namespace ShipSim.Players.Module.DataAccess;

public class PlayersDbContext : DbContext
{

    public PlayersDbContext(DbContextOptions<PlayersDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}