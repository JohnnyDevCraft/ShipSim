using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShipSim.Players.Module.Commands;
using ShipSim.Players.Module.Contracts.Exceptions;
using ShipSim.Players.Module.Contracts.Requests;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module.Handlers.Request;

internal class CreateUserRequestHandler(UserManager<Player> userManager, IMediator mediator, IMapper mapper) : IRequestHandler<CreateUserRequest, CreateUserRequestResult>
{
    public async Task<CreateUserRequestResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var existing = await mediator.Send(new GetUserByEmailRequest(request.Email), cancellationToken);
        if (existing.Player != null)
        {
            throw new UserWithEmailAlreadyExistsException(request.Email);
        }
        
        var newUser = new PlayerDto()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var createUserCommand = new CreateUserCommand(newUser, request.Password);
        var result = await mediator.Send(createUserCommand, cancellationToken);
        
        return new CreateUserRequestResult(result.Player.Id);
    }
}