using MediatR;

namespace ShipSim.Ship.Module.Contracts.Commands;

public record Action(InParams) : IRequest<ActionResult>;

public record ActionResult(OutParams);