

namespace ShipSim.Ship.Module.Entities;

internal class Ship
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Identifier { get; set; }
    public DateTime DateCreated { get; set; }
    public required string Owner { get; set; }

    public Guid ShipTypeId { get; set; }
    public ShipType ShipType { get; set; }
    
    public int MaxPowerRating { get; set; }
    public int ForwardCannonSlots { get; set; }
    public int AftCannonSlots { get; set; }
    public int SurroundPhaseArraySlots { get; set; }
    public int HullStrength { get; set; }
    public int ForwardLaunchers { get; set; }
    public int AftLaunchers { get; set; }
}