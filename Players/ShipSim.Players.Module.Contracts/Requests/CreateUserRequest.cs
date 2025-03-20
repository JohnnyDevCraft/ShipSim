using MediatR;

namespace ShipSim.Players.Module.Contracts.Requests;

public record Action(InParams) : IRequest<ActionResult>;

public record ActionResult(OutParams);