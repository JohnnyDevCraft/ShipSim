using MediatR;

namespace ShipSim.Ship.Module.Contracts.Queries;

public record Action(InParams) : IRequest<ActionResult>;

public record ActionResult(OutParams);