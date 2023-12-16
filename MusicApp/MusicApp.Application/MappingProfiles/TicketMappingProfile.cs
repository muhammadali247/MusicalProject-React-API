using AutoMapper;
using MusicApp.Application.DTOs.TicketDTOs;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.MappingProfiles;

public class TicketMappingProfile : Profile
{
    public TicketMappingProfile()
    {
        CreateMap<Ticket, TicketViewDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
           .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate))
           .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
           .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
           .ForMember(dest => dest.EventTitle, opt => opt.MapFrom(src => src.Event.Title));

        CreateMap<TicketCreateDTO, Ticket>()
            .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.Price))
            .ForMember(dest => dest.EventId, opts => opts.MapFrom(src => src.EventId))
            .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type))
            // set a default value for Status when creating
            .ForMember(dest => dest.Status, opts => opts.MapFrom(src => TicketStatus.Available));
    }
}
