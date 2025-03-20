using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShipSim.AspireConstants;
using ShipSim.ModuleCore.MappingRegistry;
using ShipSim.ModuleCore.MediatorManager;
using ShipSim.ModuleCore.MigrationTools;
using ShipSim.Race.Module.Contracts.Constants;
using ShipSim.Race.Module.DataAccess;
using ShipSim.Race.Module.Endpoints;

namespace ShipSim.Race.Module;

public static class RaceModuleHostingExtensions
{
    public static void AddRaceModule(this WebApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<RaceContext>(Defaults.RaceModule.RaceDb);
        
        MappingAssemblies.AddAssembly(typeof(RaceModuleHostingExtensions).Assembly);
        Mediators.AddAssembly(typeof(RaceModuleHostingExtensions).Assembly);
    }
    
    public static void UseRaceModule(this WebApplication app, IWebHostEnvironment env)
    {
        app.AddRaceEndpoints();
    }
    
    public static void AddRaceModuleMigrations(this HostApplicationBuilder? builder)
    {
        if(builder is null) return;
        builder.AddSqlServerDbContext<RaceContext>(Defaults.RaceModule.RaceDb);
        
        MigratorExtensions.AddMigrationApplicator(MigrateDb);
    }

    private static void MigrateDb(IServiceProvider obj)
    {
        var context = obj.GetRequiredService<RaceContext>();
        context.Database.Migrate();
        context.SeedRaces();
        context.SaveChanges();
    }

    private static void SeedRaces(this RaceContext context)
    {
        // Races Not from other SciFi Series
        context.Races.AddRange([
            new Entities.Race()
            {
                Name = "Terran",
                Description = "The Terran Race",
                Aggression = 67,
                Defense = 45,
                Logic = 59,
                Intellegence = 62,
                Strength = 39,
                Id = RaceIds.Terran
            },
            new Entities.Race()
            {
                Name = "Keltorians",
                Description = "The Keltorians",
                Aggression = 78,
                Defense = 56,
                Logic = 67,
                Intellegence = 72,
                Strength = 49,
                Id = RaceIds.Keltorians
            },
            new Entities.Race()
            {
                Name = "Korvax",
                Description = "The Korvax",
                Aggression = 82,
                Defense = 63,
                Logic = 73,
                Intellegence = 79,
                Strength = 54,
                Id = RaceIds.Korvax
            },
        ]);
    }
}