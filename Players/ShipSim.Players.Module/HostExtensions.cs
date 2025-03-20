using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ShipSim.AspireConstants;
using ShipSim.ModuleCore.MappingRegistry;
using ShipSim.ModuleCore.MediatorManager;
using ShipSim.ModuleCore.MigrationTools;
using ShipSim.Players.Module.Contracts.Configuration;
using ShipSim.Players.Module.DataAccess;
using ShipSim.Players.Module.Endpoints;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module;

public static class PlayerModuleHostExtensions
{
    public static void AddPlayersModule(this WebApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<PlayersDbContext>(Defaults.PlayerModule.SqlDb);
        
        builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

        builder.Services.AddIdentity<Player, IdentityRole<Guid>>(options =>
        {
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<PlayersDbContext>();
        
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["JwtConfig:Audience"],
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Secret"])),
                ValidateIssuerSigningKey = true,
            };
        });
        
        MappingAssemblies.AddAssembly(typeof(PlayerModuleHostExtensions).Assembly);

        builder.Services.AddAuthorization();
        
        
        Mediators.AddAssembly(typeof(PlayerModuleHostExtensions).Assembly);
    }
    
    public static void UsePlayersModule(this WebApplication app, IWebHostEnvironment env)
    {
        app.MapPlayersEndpoints();
    }
    
    public static void UserSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }

    public static void AddPlayersMigration(this HostApplicationBuilder? builder)
    {
        if (builder is null)return;
        
        builder.AddSqlServerDbContext<PlayersDbContext>(Defaults.PlayerModule.SqlDb);
        MigratorExtensions.AddMigrationApplicator(ApplyPlayersMigrations);
    }
    
    public static void ApplyPlayersMigrations(this IServiceProvider sp)
    {
        var context = sp.GetRequiredService<PlayersDbContext>();
        context.Database.Migrate();
    }
}