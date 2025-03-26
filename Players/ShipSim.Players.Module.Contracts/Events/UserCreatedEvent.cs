using ShipSim.Core;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Contracts.Events;

public class UserCreatedEvent(PlayerDto player): IEvent
{
    public DateTime EventTime { get; init; } = DateTime.UtcNow;
    public string Email { get; init; } = "System";
    public PlayerDto Player { get; set; } = player;
}