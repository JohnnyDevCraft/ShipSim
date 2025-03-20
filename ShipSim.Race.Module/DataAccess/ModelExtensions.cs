using Microsoft.EntityFrameworkCore;

namespace ShipSim.Race.Module.DataAccess;

public static class ModelExtensions
{
    public static ModelBuilder AddRaceModel(this ModelBuilder mb)
    {

        mb.Entity<Entities.Race>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name)
                .IsUnique(true);
        });

        return mb;
    }
}
