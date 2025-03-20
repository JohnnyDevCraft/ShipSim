using AutoMapper;
using ShipSim.Ship.Module.Contracts.ViewModels;
using ShipSim.Ship.Module.Entities;

namespace ShipSim.Ship.Module.Mappers;

internal class ShipTypeProfile : Profile
{
    public ShipTypeProfile()
    {
        CreateMap<ShipType, ShipTypeDto>(MemberList.None)
            .ForMember(dest => dest.MaxPowerRating,
                opt =>
                    opt.MapFrom(src => src.MaxPowerRating))
            .ForMember(dest => dest.Name,
                opt =>
                    opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id,
                opt =>
                    opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description,
                opt =>
                    opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.HullStrength,
                opt =>
                    opt.MapFrom(src => src.HullStrength))
            .ForMember(dest => dest.AftLaunchers,
                opt =>
                    opt.MapFrom(src => src.AftLaunchers))
            .ForMember(dest => dest.ForwardLaunchers,
                opt =>
                    opt.MapFrom(src => src.ForwardLaunchers))
            .ForMember(dest => dest.RaceId,
                opt =>
                    opt.MapFrom(src => src.RaceId))
            .ForMember(dest => dest.AftCannonSlots,
                opt =>
                    opt.MapFrom(src => src.AftCannonSlots))
            .ForMember(dest => dest.ForwardCannonSlots,
                opt =>
                    opt.MapFrom(src => src.ForwardCannonSlots))
            .ForMember(dest => dest.SurroundPhaseArraySlots,
                opt =>
                    opt.MapFrom(src => src.SurroundPhaseArraySlots))
            .ReverseMap();
    }
}