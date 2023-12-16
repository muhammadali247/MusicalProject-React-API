using AutoMapper;
using MusicApp.Application.DTOs.EventDTOs;
using MusicApp.WebApi.DTOs.EventApiDTOs;

namespace MusicApp.WebApi.MappingProfiles;

public class EventApiMappingProfile : Profile
{
    public EventApiMappingProfile()
    {
        CreateMap<EventCreateApiDTO, EventCreateDTO>()
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.EventDate))
               .ForMember(dest => dest.EventDuration, opt => opt.MapFrom(src => src.EventDuration))
               .ForMember(dest => dest.CoverImageUrl, opt => opt.Ignore())  // Ignored for now; will be manually set later
               .ForMember(dest => dest.LiveStreamUrl, opt => opt.MapFrom(src => src.LiveStreamUrl))
               .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.MusicalProjectIds, opt => opt.MapFrom(src => src.MusicalProjectIds));
    }
}
