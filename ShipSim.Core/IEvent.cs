using MediatR;

namespace ShipSim.Core;

public interface IEvent: INotification
{
    DateTime EventTime { get; set; }
    string UserName { get; set; }
}