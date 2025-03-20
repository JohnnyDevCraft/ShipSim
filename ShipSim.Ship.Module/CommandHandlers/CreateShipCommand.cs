using AutoMapper;
using MediatR;
using MongoDB.Driver;
using ShipSim.AspireConstants;
using ShipSim.Ship.Module.Contracts.Commands;
using ShipSim.Ship.Module.Contracts.DataTransfer;
using ShipSim.Ship.Module.Contracts.Queries;

namespace ShipSim.Ship.Module.CommandHandlers;

internal class CreateShipCommandHandler(IMongoClient mongoClient, IMapper mapper, IMediator mediator) : IRequestHandler<CreateShipCommand, CreateShipCommandResult>
{
    IMongoCollection<Entities.Ship> ships = mongoClient
        .GetDatabase(Defaults.ShipModule.ShipsDb)
        .GetCollection<Entities.Ship>(Defaults.ShipModule.ShipsCollection);
    
    public async Task<CreateShipCommandResult> Handle(CreateShipCommand request, CancellationToken cancellationToken)
    {
        var ship = new Entities.Ship
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Identifier = request.Identifier,
            DateCreated = DateTime.UtcNow,
            Owner = request.Email,
        };

        await ships.InsertOneAsync(ship, cancellationToken: cancellationToken);
        
        var shipDto = mapper.Map<ShipDto>(ship);
        
        var player = await mediator.Send(new GetCachedPlayerQuery(request.Email), cancellationToken);
        shipDto.Player = player.Player;

        return new CreateShipCommandResult(shipDto);
    }
}