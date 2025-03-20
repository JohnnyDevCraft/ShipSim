using Microsoft.EntityFrameworkCore;

namespace ShipSim.Race.Module.DataAccess;

public class RaceContext : DbContext
{

    public RaceContext(DbContextOptions<RaceContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}