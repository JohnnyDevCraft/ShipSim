using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShipSim.Players.Module.Contracts.Requests;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.Queries;

namespace ShipSim.Players.Module.Handlers.Request;

internal class GetUserByEmailRequestHandler(IMediator mediator, IMapper mapper, ILogger<GetUserByEmailRequestHandler> logger) : IRequestHandler<GetUserByEmailRequest, GetUserByEmailRequestResult>
{
    public async Task<GetUserByEmailRequestResult> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting user by email: {Email}", request.Email);
        
        var result = await mediator.Send(new GetUserByEmailQuery(request.Email), cancellationToken);
        
        logger.LogInformation("User found by email: {Email}", request.Email);
        return new GetUserByEmailRequestResult(mapper.Map<PlayerDto>(result.PlayerDto));
    }
}