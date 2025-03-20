using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using ShipSim.AspireConstants;
using ShipSim.ModuleCore.MappingRegistry;
using ShipSim.ModuleCore.MediatorManager;
using ShipSim.Race.Module.Contracts.Constants;
using ShipSim.Ship.Module.Caching;
using ShipSim.Ship.Module.Contracts.Constants;
using ShipSim.Ship.Module.Endpoints;

namespace ShipSim.Ship.Module;

public static class ShipModuleHostExtensions
{
    public static void AddShipModule(this WebApplicationBuilder builder)
    {
        builder.AddMongoDBClient(Defaults.ShipModule.ShipsDb);
        
        builder.Services.AddScoped<ICacheManager, CacheManager>();

        Mediators.AddAssembly(typeof(ShipModuleHostExtensions).Assembly);
        MappingAssemblies.AddAssembly(typeof(ShipModuleHostExtensions).Assembly);
    }

    public static void AddShipsMigration(this HostApplicationBuilder? builder)
    {
        if (builder is null) return;
        builder.AddMongoDBClient(Defaults.ShipModule.ShipsDb);
    }

    private static void MigrateDatabase(IServiceProvider obj)
    {
        var client = obj.GetRequiredService<IMongoClient>();
        var db = client.GetDatabase(Defaults.ShipModule.ShipsDb);
        
        SeedShipTypes(db);
        
    }

    public static void UseShipModule(this WebApplication app, IWebHostEnvironment env)
    {
        app.AddShipEndpoints();
    }

    private static void SeedShipTypes(this IMongoDatabase db)
    {
        var shipTypes = db.GetCollection<Entities.ShipType>(Defaults.ShipModule.ShipTypesCollection);
        
        shipTypes.InsertMany(
        [
        
                    new Entities.ShipType()
                    {
                        Name = "Defiant Class",
                        Description = "A small and powerful warship",
                        AftLaunchers = 2,
                        ForwardLaunchers = 2,
                        AftCannonSlots = 0,
                        ForwardCannonSlots = 4,
                        HullStrength = 800,
                        MaxPowerRating = 100000,
                        RaceId = RaceIds.Terran,
                        SurroundPhaseArraySlots = 0,
                        Id = ShipTypes.Terran.DefiantClass
                    },
                    new Entities.ShipType()
                    {
                        Name = "Galaxy Class",
                        Description = "A large and powerful Exploration Ship",
                        AftLaunchers = 4,
                        ForwardLaunchers = 4,
                        AftCannonSlots = 2,
                        ForwardCannonSlots = 6,
                        HullStrength = 2000,
                        MaxPowerRating = 200000,
                        RaceId = RaceIds.Terran,
                        SurroundPhaseArraySlots = 2,
                        Id = ShipTypes.Terran.GalaxyClass
                    },
                    new Entities.ShipType()
                    {
                        Name = "Keltorian Scout",
                        Description = "A small and fast scout ship",
                        AftLaunchers = 0,
                        ForwardLaunchers = 0,
                        AftCannonSlots = 0,
                        ForwardCannonSlots = 2,
                        HullStrength = 30,
                        MaxPowerRating = 15000,
                        RaceId = RaceIds.Keltorians,
                        SurroundPhaseArraySlots = 0,
                        Id = ShipTypes.Keltorian.KeltorianScout
                    }
                ]
            );
        
        
    }
}