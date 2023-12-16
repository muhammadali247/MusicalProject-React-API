using AutoMapper;
using MusicApp.Application.DTOs.EventDTOs;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.MappingProfiles;

public class EventMappingProfile : Profile
{
    public EventMappingProfile()
    {
        CreateMap<Event, EventViewDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.EventDate))
           .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => BuildImageUrl(src.CoverImageUrl)))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
           .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
           .ForMember(dest => dest.MusicalProjectNames, opt => opt.MapFrom(src => src.MusicalProjectEvents.Select(mpe => mpe.MusicalProject.Name).ToList()))
           .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.Tickets == null ? 0 : src.Tickets.Count))
           .ReverseMap();

        CreateMap<EventCreateDTO, Event>()
              .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.EventDate))
              .ForMember(dest => dest.EventDuration, opt => opt.MapFrom(src => src.EventDuration))
              .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.CoverImageUrl))
              .ForMember(dest => dest.LiveStreamUrl, opt => opt.MapFrom(src => src.LiveStreamUrl))
              .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.HasValue ? src.Status.Value : EventStatus.Draft))
              .ForMember(dest => dest.MusicalProjectEvents, opt => opt.MapFrom(src => src.MusicalProjectIds.Select(projectId => new MusicalProjectEvent { MusicalProjectId = projectId })));
    }

    private string BuildImageUrl(string fileName)
    {
        return $"/images/events/{fileName}";
    }

}

