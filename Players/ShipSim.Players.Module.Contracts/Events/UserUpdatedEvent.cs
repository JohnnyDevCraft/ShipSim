using ShipSim.Core;
using ShipSim.Players.Module.Contracts.ViewModels;

namespace ShipSim.Players.Module.Contracts.Events;

public record UserUpdatedEvent(DateTime EventTime, string Email, PlayerDto Player): IEvent;