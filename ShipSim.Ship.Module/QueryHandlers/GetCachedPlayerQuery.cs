using MediatR;
using Microsoft.Extensions.Logging;
using ShipSim.AspireConstants;
using ShipSim.Players.Module.Contracts.Requests;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Ship.Module.Caching;
using ShipSim.Ship.Module.Contracts.Queries;

namespace ShipSim.Ship.Module.QueryHandlers;

internal class GetCachedPlayerQueryHandler(ICacheManager cm, IMediator mediator, ILogger<GetCachedPlayerQueryHandler> logger) : IRequestHandler<GetCachedPlayerQuery, GetCachedPlayerQueryResult>
{
    public async Task<GetCachedPlayerQueryResult> Handle(GetCachedPlayerQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting player by email from ships cache: {Email}", request.Email);
        
        var player = cm.GetAsync<PlayerDto>(Defaults.ShipModule.RedisPlayersPrefix, request.Email).Result;
        if (player == null)
        {
            logger.LogInformation("Player not found in ships cache, getting from players module: {Email}", request.Email);
            var playerResult = await mediator.Send(new GetUserByEmailRequest(request.Email), cancellationToken);
            
            logger.LogInformation("Caching player from players module: {Email}", request.Email);
            await cm.SetAsync(string.Format(Defaults.ShipModule.RedisPlayersPrefix, request.Email), playerResult.Player);
            player = playerResult.Player;
        }
        
        logger.LogInformation("Player found by email: {Email}", request.Email);
        return new GetCachedPlayerQueryResult(player);
    }
}