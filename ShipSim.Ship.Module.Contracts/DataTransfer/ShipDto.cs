using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Ship.Module.Contracts.ViewModels;

namespace ShipSim.Ship.Module.Contracts.DataTransfer;

public class ShipDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Identifier { get; set; }
    public DateTime DateCreated { get; set; }
    public string Owner { get; set; }
    
    public PlayerDto? Player { get; set; }
    
    public Guid ShipTypeId { get; set; }
    public ShipTypeDto? ShipType { get; set; }
    
    public int MaxPowerRating { get; set; }
    public int ForwardCannonSlots { get; set; }
    public int AftCannonSlots { get; set; }
    public int SurroundPhaseArraySlots { get; set; }
    public int HullStrength { get; set; }
    public int ForwardLaunchers { get; set; }
    public int AftLaunchers { get; set; }
    
}