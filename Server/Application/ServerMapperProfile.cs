using AutoMapper;
using CarsManagement.Server.Domain.Entities;
using CarsManagement.Shared.DTO;

namespace CarsManagement.Server.Application;

public class ServerMapperProfile : Profile
{
    public ServerMapperProfile()
    {
        // Mapping for ManagerModel and ManagerDTO
        CreateMap<ManagerModel, ManagerDTO>()
            .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ManagerId));

        // Updated Mapping for CarModel and CarDTO
        CreateMap<CarModel, CarDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Ticket, opt => opt.MapFrom(src => src.Ticket))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Ticket, opt => opt.MapFrom(src => src.Ticket));

        // Mapping for LotModel and ParkingLotDTO
        CreateMap<LotModel, ParkingLotDTO>()
            .ForMember(dest => dest.LotId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
            .ForMember(dest => dest.LotName, opt => opt.MapFrom(src => src.LotName))
            .ForMember(dest => dest.LotLocation, opt => opt.MapFrom(src => src.LotLocation))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LotId))
            .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
            .ForMember(dest => dest.LotName, opt => opt.MapFrom(src => src.LotName))
            .ForMember(dest => dest.LotLocation, opt => opt.MapFrom(src => src.LotLocation));

        // Mapping for SpotModel and ParkingSpotDTO
        CreateMap<SpotModel, ParkingSpotDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsOccupied, opt => opt.MapFrom(src => src.IsOccupied))
            .ForMember(dest => dest.IsInclusive, opt => opt.MapFrom(src => src.IsInclusive))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsOccupied, opt => opt.MapFrom(src => src.IsOccupied))
            .ForMember(dest => dest.IsInclusive, opt => opt.MapFrom(src => src.IsInclusive));

        // Mapping for TicketModel and TicketDTO
        CreateMap<TicketModel, TicketDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.AmountPaid, opt => opt.MapFrom(src => src.AmountPaid))
            .ForMember(dest => dest.EntryTime, opt => opt.MapFrom(src => src.EntryTime))
            .ForMember(dest => dest.ExitTime, opt => opt.MapFrom(src => src.ExitTime))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.AmountPaid, opt => opt.MapFrom(src => src.AmountPaid))
            .ForMember(dest => dest.EntryTime, opt => opt.MapFrom(src => src.EntryTime))
            .ForMember(dest => dest.ExitTime, opt => opt.MapFrom(src => src.ExitTime));
    }
}