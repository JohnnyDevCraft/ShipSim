using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ShipSim.Ship.Module.Contracts.Commands;

namespace ShipSim.Ship.Module.Endpoints;

internal static class ShipEndpoints
{
    public static void AddShipEndpoints(this WebApplication app)
    {
        app.MapPost("/ships", async (IMediator mediator, CreateShipCommand request, HttpContext ctx) =>
        {
            var email = ctx.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var result = await mediator.Send(request with { Email = email });

            return Results.Created($"/ships/{result.Ship.Id}", result.Ship);
        }).RequireAuthorization();
    }
    
}