namespace ShipSim.Race.Module.Contracts.ViewModels;

public class RaceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int Aggression { get; set; }
    public int Defense { get; set; }
    public int Logic { get; set; }
    public int Intellegence { get; set; }
    public int Strength { get; set; }
}