using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.DataAccess;
using ShipSim.Players.Module.Queries;

namespace ShipSim.Players.Module.Handlers.Query;

internal class GetUserByEmailQueryHandler(PlayersDbContext context, ILogger<GetUserByEmailQueryHandler> logger, IMapper mapper) : IRequestHandler<GetUserByEmailQuery, GetUserByEmailQueryResult>
{
    public async Task<GetUserByEmailQueryResult> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting user by email: {Email}", request.Email);
        var user = await context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
        
        return new GetUserByEmailQueryResult(user == null ? null : mapper.Map<PlayerDto>(user));
    }
}