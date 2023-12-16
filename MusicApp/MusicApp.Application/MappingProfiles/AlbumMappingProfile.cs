using AutoMapper;
using MusicApp.Application.DTOs.AlbumDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.MappingProfiles;

public class AlbumMappingProfile : Profile
{
    public AlbumMappingProfile()
    {
        CreateMap<Album, AlbumViewDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
            .ForMember(dest => dest.MusicalProjectName, opt => opt.MapFrom(src => src.MusicalProject.Name)) 
            .ForMember(dest => dest.MainCoverAlbumImageUrl, opt => opt.MapFrom(src => BuildImageUrl(src.MainCoverAlbumImage.ImageUrl))) 
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.AlbumImages.Select(img => BuildImageUrl(img.ImageUrl)).ToList()))
            .ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.AlbumGenres.Select(ag => ag.Genre.Name).ToList())) 
            .ForMember(dest => dest.SongTitles, opt => opt.MapFrom(src => src.Songs.Select(song => song.Title).ToList()));

        CreateMap<AlbumCreateDTO, Album>()
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
                 .ForMember(dest => dest.MusicalProjectId, opt => opt.MapFrom(src => src.MusicalProjectId))
                 .ForMember(dest => dest.AlbumGenres, opt => opt.MapFrom(src => src.GenreIds.Select(genreId => new AlbumGenre { GenreId = genreId })))
                 .ForMember(dest => dest.AlbumImages, opt => opt.MapFrom(src => CreateAlbumImages(src)))
                 .ForMember(dest => dest.Songs, opt => opt.MapFrom(src => src.Songs.Select(s => new Song
                 {
                     Title = s.Title,
                     DurationInSeconds = s.DurationInSeconds
                 })));
    }

    private string BuildImageUrl(string fileName)
    {
        return $"/images/albums/{fileName}";
    }

    private List<AlbumImage> CreateAlbumImages(AlbumCreateDTO src)
    {
        return src.AlbumImages.Select(img => new AlbumImage
        {
            ImageUrl = img.ImageUrl,
            IsMainCover = img.IsMainCover
        }).ToList();
    }
}
