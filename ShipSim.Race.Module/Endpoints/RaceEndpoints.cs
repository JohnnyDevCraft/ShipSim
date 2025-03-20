using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ShipSim.Race.Module.Contracts.Requests;

namespace ShipSim.Race.Module.Endpoints;

public static class RaceEndpoints
{
    private const string RacePrefix = "api/Race";
    
    public static void AddRaceEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(RacePrefix);
        
        group.MapGet("", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetAllRacesRequests(), cancellationToken);
            return Results.Ok(result.Races);
        }).RequireAuthorization();
    }
}