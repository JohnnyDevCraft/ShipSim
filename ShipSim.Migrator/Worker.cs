using ShipSim.ModuleCore.MigrationTools;

namespace ShipSim.Migrator;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _serviceProvider.ApplyMigrations(_logger);
        return Task.CompletedTask;
    }
}