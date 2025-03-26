using MediatR;

namespace ShipSim.Core;

public interface IEvent: INotification
{
    DateTime EventTime { get; init; }
    string Email { get; init; }
}