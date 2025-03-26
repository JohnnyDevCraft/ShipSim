using ShipSim.Ship.Module.Contracts.Enums;

namespace ShipSim.Ship.Module.Entities;

public class Equipment
{
    public EquipmentType Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int OffPowerUsage { get; set; }
    public int MinPowerRating { get; set; }
    public int MaxPowerRating { get; set; }
    public int ResilienceRating { get; set; }
    public List<DamageModifier> ActiveDamage { get; set; }
}

public class DamageModifier
{
    public int DamageDealt { get; set; }
}

public class Cannon : Equipment
{
    public int MaxDamage { get; set; }
    public int MinDamage { get; set; }
    public int Range { get; set; }
    public int Accuracy { get; set; }
}

public class Launcher : Equipment
{
    public int MaxDamage { get; set; }
    public int MinDamage { get; set; }
    public int Range { get; set; }
    public int Accuracy { get; set; }
}

public class PhaseArray : Equipment
{
    public int MaxDamage { get; set; }
    public int MinDamage { get; set; }
    public int Range { get; set; }
    public int Accuracy { get; set; }
}

public class Hull : Equipment
{
    public int HullStrength { get; set; }
}

public class Engine : Equipment
{
    public int MaxSpeed { get; set; }
}

public class Shield : Equipment
{
    public int ShieldStrength { get; set; }
}

public class PowerPlant : Equipment
{
    public int MaxPowerOutput { get; set; }
    public int MinPowerOutput { get; set; }
    public int DamageOverMod { get; set; }
}

public class ScannerArray : Equipment
{
    public int Range { get; set; }
    public int Accuracy { get; set; }
}

public class DeflectorArray : Equipment
{
    public int Range { get; set; }
    public int Accuracy { get; set; }
}

public class TractorBeam : Equipment
{
    public int Range { get; set; }
    public int Strength { get; set; }
}

public class CloakingDevice : Equipment
{
    public int ScanAccuracy { get; set; }
}

public class Transporter : Equipment
{
    public int Range { get; set; }
}

public class DamageControlBot : Equipment
{
    public int RepairRate { get; set; }
}


