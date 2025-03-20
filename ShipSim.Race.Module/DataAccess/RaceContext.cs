using Microsoft.EntityFrameworkCore;

namespace ShipSim.Race.Module.DataAccess;

internal class RaceContext : DbContext
{
    public DbSet<Entities.Race> Races { get; set; }
    
    public RaceContext(DbContextOptions<RaceContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddRaceModel();
    }
}