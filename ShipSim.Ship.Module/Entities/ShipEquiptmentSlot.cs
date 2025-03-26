using ShipSim.Ship.Module.Contracts.Enums;

namespace ShipSim.Ship.Module.Entities;

public class ShipEquipmentSlot
{
    public EquipmentType EquipmentType { get; set; }
    public Equipment EquipmentAssigned { get; set; }
    
}