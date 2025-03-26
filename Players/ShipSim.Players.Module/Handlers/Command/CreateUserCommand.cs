using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ShipSim.Players.Module.Commands;
using ShipSim.Players.Module.Contracts.Exceptions;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module.Handlers.Command;

internal class CreateUserCommandHandler(UserManager<Player> playerManager, IMapper mapper, ILogger<CreateUserCommandHandler> logger) : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
{
    public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating user: {Email}", request.Player.Email);

        try
        {
            var player = new Player()
            {
                Email = request.Player.Email,
                FirstName = request.Player.FirstName,
                UserName = request.Player.Email,
                LastName = request.Player.LastName
            };
            var result = await playerManager.CreateAsync(player, request.Password);
            var resultDto = mapper.Map<PlayerDto>(player);
            return new CreateUserCommandResult(resultDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to create user: {Email}", request.Player.Email);
            throw new FailedToCreateUserException(request.Player.Email);
        }
    }
}