using ShipSim.Migrator;
using ShipSim.Players.Module;
using ShipSim.Race.Module;
using ShipSim.Ship.Module;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.AddServiceDefaults();

builder.AddPlayersMigration();
builder.AddShipsMigration();
builder.AddRaceModuleMigrations();

builder.Services.AddOpenTelemetry()
    .WithTracing();

var host = builder.Build();

host.Run();