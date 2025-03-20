using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module.DataAccess;

internal class PlayersDbContext : IdentityDbContext<Player, IdentityRole<Guid>, Guid>
{

    public PlayersDbContext(DbContextOptions<PlayersDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}