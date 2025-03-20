using AutoMapper;
using ShipSim.Ship.Module.Contracts.DataTransfer;
using ShipSim.Ship.Module.Contracts.ViewModels;

namespace ShipSim.Ship.Module.Mappers;

internal class ShipProfile : Profile
{
    public ShipProfile()
    {
        CreateMap<Entities.Ship, ShipDto>(MemberList.None)
            .ForMember(dest => dest.Owner,
                opt =>
                    opt.MapFrom(src => src.Owner))
            .ForMember(dest => dest.Name,
                opt =>
                    opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id,
                opt =>
                    opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Identifier,
                opt =>
                    opt.MapFrom(src => src.Identifier))
            .ForMember(dest => dest.DateCreated,
                opt =>
                    opt.MapFrom(src => src.DateCreated))
            .ForMember(dest => dest.MaxPowerRating,
                opt =>
                    opt.MapFrom(src => src.MaxPowerRating))
            .ForMember(dest => dest.HullStrength,
                opt =>
                    opt.MapFrom(src => src.HullStrength))
            .ForMember(dest => dest.AftLaunchers,
                opt =>
                    opt.MapFrom(src => src.AftLaunchers))
            .ForMember(dest => dest.ForwardLaunchers,
                opt =>
                    opt.MapFrom(src => src.ForwardLaunchers))
            .ForMember(dest => dest.AftCannonSlots,
                opt =>
                    opt.MapFrom(src => src.AftCannonSlots))
            .ForMember(dest => dest.ForwardCannonSlots,
                opt =>
                    opt.MapFrom(src => src.ForwardCannonSlots))
            .ForMember(dest => dest.SurroundPhaseArraySlots,
                opt =>
                    opt.MapFrom(src => src.SurroundPhaseArraySlots))
            .ForMember(dest => dest.ShipType,
                opt =>
                    opt.MapFrom(src => src.ShipType))
            .ReverseMap();
    }
}