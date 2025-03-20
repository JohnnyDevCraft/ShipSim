namespace ShipSim.Ship.Module.Entities;

internal class ShipType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid RaceId { get; set; }
    
    public int MaxPowerRating { get; set; }
    public int ForwardCannonSlots { get; set; }
    public int AftCannonSlots { get; set; }
    public int SurroundPhaseArraySlots { get; set; }
    public int HullStrength { get; set; }
    public int ForwardLaunchers { get; set; }
    public int AftLaunchers { get; set; }
}