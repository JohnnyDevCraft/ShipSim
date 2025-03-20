using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShipSim.Race.Module.Contracts.Exceptions;
using ShipSim.Race.Module.Contracts.Requests;
using ShipSim.Race.Module.Contracts.ViewModels;
using ShipSim.Race.Module.DataAccess;

namespace ShipSim.Race.Module.RequestHandlers;

internal class GetRaceByIdRequestHandler(RaceContext context, IMapper mapper) : IRequestHandler<GetRaceByIdRequest, GetRaceByIdRequestResult>
{
    public async Task<GetRaceByIdRequestResult> Handle(GetRaceByIdRequest request, CancellationToken cancellationToken)
    {
        var race = await context.Races.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        
        if (race == null)
        {
            throw new RaceNotFoundByIdException(request.Id);
        }
        
        return new GetRaceByIdRequestResult(mapper.Map<RaceDto>(race));
    }
}