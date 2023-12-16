using AutoMapper;
using MusicApp.Application.DTOs.SongDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.MappingProfiles;

public class SongMappingProfile : Profile
{
    public SongMappingProfile()
    {
        CreateMap<Song, SongViewDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.DurationInSeconds, opt => opt.MapFrom(src => src.DurationInSeconds))
            .ForMember(dest => dest.TrackOrderNumber, opt => opt.MapFrom(src => src.TrackOrderNumber))
            .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
            .ForMember(dest => dest.LyricsContent, opt => opt.MapFrom(src => src.Lyrics.Content)).ReverseMap();
    }
}
