using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShipSim.Players.Module.Commands;
using ShipSim.Players.Module.Contracts.Events;
using ShipSim.Players.Module.Contracts.Exceptions;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.DataAccess;

namespace ShipSim.Players.Module.Handlers.Command;

internal class ChangeNamesForUserCommandHandler(PlayersDbContext db, IMapper mapper, IMediator mediator) : IRequestHandler<ChangeNamesForUserCommand, ChangeNamesForUserCommandResult>
{
    public async Task<ChangeNamesForUserCommandResult> Handle(ChangeNamesForUserCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implement the logic to change the user name
        var player = await db.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
        
        if (player == null)
        {
            throw new UserByEmailNotFoundException(request.Email);
        }
        
        player.FirstName = request.FirstName;
        player.LastName = request.LastName;
        
        await db.SaveChangesAsync(cancellationToken);
        var dto = mapper.Map<PlayerDto>(player);
        
        // TODO: Add the event code here
        
        return new ChangeNamesForUserCommandResult(mapper.Map<PlayerDto>(player));
    }
}