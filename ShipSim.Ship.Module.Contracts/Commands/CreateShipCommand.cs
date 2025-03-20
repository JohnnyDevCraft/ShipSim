using MediatR;
using ShipSim.Ship.Module.Contracts.DataTransfer;
using ShipSim.Ship.Module.Contracts.ViewModels;

namespace ShipSim.Ship.Module.Contracts.Commands;

public record CreateShipCommand(
    string Name,
    string Identifier,
    string Email,
    Guid ShipTypeId,
    int MaxPowerRating,
    int ForwardCannonSlots,
    int AftCannonSlots,
    int SurroundPhaseArraySlots,
    int HullStrength,
    int ForwardLaunchers,
    int AftLaunchers
    ) : IRequest<CreateShipCommandResult>;

public record CreateShipCommandResult(ShipDto Ship);