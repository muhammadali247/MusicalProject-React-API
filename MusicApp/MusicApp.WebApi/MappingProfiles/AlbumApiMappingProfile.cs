using AutoMapper;
using MusicApp.Application.DTOs.AlbumDTOs;
using MusicApp.WebApi.DTOs.AlbumApiDTOs;

namespace MusicApp.WebApi.MappingProfiles;

public class AlbumApiMappingProfile : Profile
{
    public AlbumApiMappingProfile()
    {
         CreateMap<AlbumCreateApiDTO, AlbumCreateDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
            .ForMember(dest => dest.MusicalProjectId, opt => opt.MapFrom(src => src.MusicalProjectId))
            .ForMember(dest => dest.AlbumImages, opt => opt.Ignore())  
            .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.Songs))
            .ForMember(dest => dest.GenreIds, opt => opt.MapFrom(src => src.GenreIds));

        CreateMap<AlbumImageToAddApiDTO, AlbumImageToAddDTO>()
           .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())  // set this post-mapping using _fileUploadService
           .ForMember(dest => dest.IsMainCover, opt => opt.MapFrom(src => src.IsMainCover));

        CreateMap<SongToAddApiDTO, SongToAddDTO>();
    }
}
