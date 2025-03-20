using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShipSim.AspireConstants;
using ShipSim.ModuleCore.MediatorManager;
using ShipSim.ModuleCore.MigrationTools;
using ShipSim.Players.Module.Contracts.Configuration;
using ShipSim.Players.Module.DataAccess;
using ShipSim.Players.Module.Endpoints;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module;

public static class HostExtensions
{
    public static void AddPlayersModule(this WebApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<PlayersDbContext>(Defaults.PlayerModule.SqlDb);
        
        builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

        builder.Services.AddIdentity<Player, IdentityRole<Guid>>(options =>
        {
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<PlayersDbContext>();
        
        Mediators.AddAssembly(typeof(HostExtensions).Assembly);
    }
    
    public static void UsePlayersModule(this WebApplication app, IWebHostEnvironment env)
    {
        app.MapPlayersEndpoints();
    }

    public static void AddPlayersMigration(this HostApplicationBuilder? builder)
    {
        if (builder is null)
        {
            return;
        }
        
        builder.AddSqlServerDbContext<PlayersDbContext>(Defaults.PlayerModule.SqlDb);
    }
    
    public static void ApplyPlayersMigrations(this IServiceProvider sp)
    {
        using var scope = sp.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<PlayersDbContext>();
        context.Database.Migrate();
    }
}