using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ShipSim.ModuleCore.MigrationTools;

public static class MigratorExtensions
{
    private static List<Action<IServiceProvider>> _migrators = new();

    private static void MigrateDb(this IServiceProvider services, Action<IServiceProvider>? migrator = null) 
    {
        using var scope = services.CreateScope();
        var sp = scope.ServiceProvider;
        migrator?.Invoke(sp);
    }
    
    public static void AddMigrationApplicator(Action<IServiceProvider> applicator)
    {
        _migrators.Add(applicator);
    }
    
    public static void ApplyMigrations(this IServiceProvider sp, ILogger logger)
    {
        foreach (var applicator in _migrators)    
        {
            try
            {
                logger.LogInformation("Applying migration");
                sp.MigrateDb(applicator);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error applying migration");
            }
        }
    }
}