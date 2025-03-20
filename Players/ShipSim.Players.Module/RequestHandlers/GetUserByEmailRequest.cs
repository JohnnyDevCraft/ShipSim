using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ShipSim.Players.Module.Contracts.Exceptions;
using ShipSim.Players.Module.Contracts.Requests;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.DataAccess;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module.RequestHandlers;

internal class GetUserByEmailRequestHandler(UserManager<Player> um, IMapper mapper, ILogger<GetUserByEmailRequestHandler> logger) : IRequestHandler<GetUserByEmailRequest, GetUserByEmailRequestResult>
{
    public async Task<GetUserByEmailRequestResult> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting user by email: {Email}", request.Email);
        var user = await um.FindByEmailAsync(request.Email);

        if (user == null)
        {
            var exception = new UserByEmailNotFoundException(request.Email);
            logger.LogError(exception, "User not found by email: {Email}", request.Email);
            throw exception;
        }
        
        logger.LogInformation("User found by email: {Email}", request.Email);
        return new GetUserByEmailRequestResult(mapper.Map<PlayerDto>(user));
    }
}