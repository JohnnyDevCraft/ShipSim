using ShipSim.Core;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Contracts.Events;

public class UserSignedInEvent(PlayerDto playerDto): IEvent
{
    public DateTime EventTime { get; set; } = DateTime.UtcNow;
    public string UserName { get; set; } = "System";
    public PlayerDto Player { get; set; } = playerDto;
}