using MediatR;

namespace ShipSim.Race.Module.Contracts.Requests;

public record Action(InParams) : IRequest<ActionResult>;

public record ActionResult(OutParams);