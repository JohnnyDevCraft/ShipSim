using MediatR;
using Scalar.AspNetCore;
using ShipSim.AspireConstants;
using ShipSim.ModuleCore.MappingRegistry;
using ShipSim.ModuleCore.MediatorManager;
using ShipSim.Players.Module;
using ShipSim.Race.Module;
using ShipSim.Ship.Module;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.AddServiceDefaults();
builder.AddRedisClient(Defaults.RedisCache);

builder.AddPlayersModule();
builder.AddShipModule();
builder.AddRaceModule();

builder.Services.AddAutoMapper(MappingAssemblies.GetAssemblies().ToArray());


builder.Services.AddMediatR(Mediators.GetAssemblies().ToArray());

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UserSecurity();

app.UsePlayersModule(app.Environment);
app.UseShipModule(app.Environment);
app.UseRaceModule(app.Environment);



app.Run();

