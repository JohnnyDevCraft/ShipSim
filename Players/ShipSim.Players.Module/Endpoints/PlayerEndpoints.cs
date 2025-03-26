using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ShipSim.Players.Module.Contracts.Requests;

namespace ShipSim.Players.Module.Endpoints;

internal static class PlayerEndpoints
{
    internal static void MapPlayersEndpoints(this WebApplication app)
    {
        app.MapPost("/players", async (IMediator mediator, CreateUserRequest request) =>
        {
            var result = await mediator.Send(request);
            return Results.Created($"/players/{result.UserId}", result);
        });
        
        app.MapPost("/players/sign-in", async (IMediator mediator, SignInUserRequest request) =>
        {
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
        
        app.MapPut("/players/my-name", async (IMediator mediator, ChangeNamesForUserRequest request) =>
        {
            var result = await mediator.Send(request);
            return Results.Ok(result);
        }).RequireAuthorization().RequireCors();

    }
}