using MediatR;
using ShipSim.Race.Module.Contracts.ViewModels;

namespace ShipSim.Race.Module.Contracts.Requests;

public record GetAllRacesRequests() : IRequest<GetAllRacesRequestsResult>;

public record GetAllRacesRequestsResult(IEnumerable<RaceDto> Races);