using AutoMapper;
using ShipSim.Race.Module.Contracts.ViewModels;

namespace ShipSim.Race.Module.Mappings;

internal class RaceProfile : Profile
{
    public RaceProfile()
    {
        CreateMap<Entities.Race, RaceDto>().ReverseMap();
    }
}