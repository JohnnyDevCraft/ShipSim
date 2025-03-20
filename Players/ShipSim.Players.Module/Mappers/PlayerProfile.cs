using AutoMapper;
using ShipSim.Players.Module.Contracts.ViewModels;
using ShipSim.Players.Module.Entities;

namespace ShipSim.Players.Module.Mappers;

internal class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<Player, PlayerDto>(MemberList.None)
            .ForMember(dest => dest.Id,
                opt =>
                    opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName,
                opt =>
                    opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName,
                opt =>
                    opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email,
                opt =>
                    opt.MapFrom(src => src.Email))
            .ReverseMap();
    }
}
