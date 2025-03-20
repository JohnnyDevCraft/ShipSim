using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShipSim.Race.Module.Contracts.Requests;
using ShipSim.Race.Module.Contracts.ViewModels;
using ShipSim.Race.Module.DataAccess;

namespace ShipSim.Race.Module.RequestHandlers;

internal class GetAllRacesRequestsHandler(RaceContext db, IMapper mapper) : IRequestHandler<GetAllRacesRequests, GetAllRacesRequestsResult>
{
    public async Task<GetAllRacesRequestsResult> Handle(GetAllRacesRequests request, CancellationToken cancellationToken)
    {
        var result = await db.Races.ToListAsync(cancellationToken);
        return new GetAllRacesRequestsResult(result.Select(x => mapper.Map<RaceDto>(x)).ToList());
    }
}