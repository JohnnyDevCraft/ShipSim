using MediatR;
using ShipSim.Race.Module.Contracts.ViewModels;

namespace ShipSim.Race.Module.Contracts.Requests;

public record GetRaceByIdRequest(Guid Id) : IRequest<GetRaceByIdRequestResult>;

public record GetRaceByIdRequestResult(RaceDto Race);