using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShipSim.Players.Module.Contracts.Events;
using ShipSim.Players.Module.Contracts.Requests;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module.RequestHandlers;

internal class CreateUserRequestHandler(UserManager<Player> userManager, IMediator mediator, IMapper mapper) : IRequestHandler<CreateUserRequest, CreateUserRequestResult>
{
    public async Task<CreateUserRequestResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var newUser = new Player
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        
        var result = await userManager.CreateAsync(newUser, request.Password);
        
        if (!result.Succeeded)
        {
            throw new Exception("Failed to create user");
        }

        await mediator.Publish(new UserCreatedEvent(mapper.Map<PlayerDto>(newUser)), cancellationToken);
        return new CreateUserRequestResult(newUser.Id);
    }
}