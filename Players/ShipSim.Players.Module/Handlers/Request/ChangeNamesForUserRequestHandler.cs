using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ShipSim.Core.Exceptions;
using ShipSim.Players.Module.Commands;
using ShipSim.Players.Module.Contracts.Requests;
using ShipSim.Players.Module.Queries;

namespace ShipSim.Players.Module.Handlers.Request;

public class ChangeNamesForUserRequestHandler(IMediator mediator, ILogger<ChangeNamesForUserRequestHandler> logger, IHttpContextAccessor accessor) : IRequestHandler<ChangeNamesForUserRequest, ChangeNamesForUserRequestResult>
{
    public async Task<ChangeNamesForUserRequestResult> Handle(ChangeNamesForUserRequest request, CancellationToken cancellationToken)
    {
        var email = accessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        
        if (email == null)
        {
            var ex =  new UserUnauthenticatedException();
            logger.LogError(ex, "User is not authenticated");
            throw ex;
        }
        
        logger.LogInformation("Change names for user: {Email}", email);
        
        var user = await mediator.Send(new GetUserByEmailQuery(email), cancellationToken);
        
        var updatedUser = await mediator.Send(new ChangeNamesForUserCommand(request.FirstName, request.LastName, email), cancellationToken);
        
        return new ChangeNamesForUserRequestResult(updatedUser.Player);
    }
}