using System.Security.Claims;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using ShipSim.AspireConstants;
using ShipSim.Ship.Module.Caching;
using ShipSim.Ship.Module.Contracts.Commands;
using ShipSim.Ship.Module.Contracts.DataTransfer;

namespace ShipSim.Ship.Module.CommandHandlers;

public class CreateShipCommandHandler(IMongoClient mongoClient, IMapper mapper, PlayerCacheService pcs) : IRequestHandler<CreateShipCommand, CreateShipCommandResult>
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
        
        shipDto.Player = pcs.GetPlayerAsync(Guid.Parse(request.Email)).Result;
        

        return new CreateShipCommandResult(shipDto);
    }
}