using AutoMapper;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.MappingProfiles;

public class MusicalProjectMappingProfile : Profile
{
    public MusicalProjectMappingProfile()
    {
        CreateMap<MusicalProject, MusicalProjectViewDTO>()
           .ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.MusicalProjectGenres.Select(g => g.Genre.Name)))
           .ForMember(dest => dest.ArtistNames, opt => opt.MapFrom(src => src.ArtistMusicalProjects.Select(amp => amp.Artist.ArtistName)))
           .ForMember(dest => dest.SocialMediaLinkUrls, opt => opt.MapFrom(src => src.SocialMediaLinks.Select(sm => sm.Url)))
           .ForMember(dest => dest.AlbumTitles, opt => opt.MapFrom(src => src.Albums.Select(a => a.Title))).ReverseMap();

        CreateMap<MusicalProjectCreateDTO, MusicalProject>()
            .ForMember(dest => dest.ArtistMusicalProjects, opt => opt.MapFrom(src => src.ArtistIds.Select(artistId => new ArtistMusicalProject { ArtistId = artistId })))
            .ForMember(dest => dest.MusicalProjectGenres, opt => opt.MapFrom(src => src.GenreIds.Select(genreId => new MusicalProjectGenre { GenreId = genreId })))
            .ForMember(dest => dest.SocialMediaLinks, opt => opt.MapFrom(src => src.SocialMediaLinks.Select(smDto => new SocialMediaLink
            {
                Platform = smDto.Platform,
                Url = smDto.Url,
                EntityType = "MusicalProject"
            })));

        CreateMap<MusicalProjectUpdateDTO, MusicalProject>()
            .ForMember(dest => dest.Name, opts => opts.Condition(src => src.Name != null))
            .ForMember(dest => dest.Description, opts => opts.Condition(src => src.Description != null))
            .ForMember(dest => dest.DateFounded, opts => opts.Condition(src => src.DateFounded.HasValue))
            .ForMember(dest => dest.DateCanceled, opts => opts.Condition(src => src.DateCanceled.HasValue))
            .AfterMap((src, dest) =>
             {
                 // Handle adding artists
                 if (src.ArtistIdsToAdd != null && src.ArtistIdsToAdd.Any())
                 {
                     foreach (var artistId in src.ArtistIdsToAdd)
                     {
                         if (!dest.ArtistMusicalProjects.Any(amp => amp.ArtistId == artistId))
                         {
                             dest.ArtistMusicalProjects.Add(new ArtistMusicalProject { ArtistId = artistId });
                         }
                     }
                 }

                 // Handle removing artists
                 if (src.ArtistIdsToRemove != null && src.ArtistIdsToRemove.Any())
                 {
                     dest.ArtistMusicalProjects.RemoveAll(amp => src.ArtistIdsToRemove.Contains(amp.ArtistId));
                 }


                 // Handle adding genres
                 if (src.GenreIdsToAdd != null && src.GenreIdsToAdd.Any())
                 {
                     foreach (var genreId in src.GenreIdsToAdd)
                     {
                         if (!dest.MusicalProjectGenres.Any(mpg => mpg.GenreId == genreId))
                         {
                             dest.MusicalProjectGenres.Add(new MusicalProjectGenre { GenreId = genreId });
                         }
                     }
                 }


                 // Handle removing genres
                 if (src.GenreIdsToRemove != null && src.GenreIdsToRemove.Any())
                 {
                     dest.MusicalProjectGenres.RemoveAll(mpg => src.GenreIdsToRemove.Contains(mpg.GenreId));
                 }
                 

                 // Handle adding new social media links
                 foreach (var link in src.SocialMediaLinksToAdd)
                 {
                     dest.SocialMediaLinks.Add(new SocialMediaLink { Platform = link.Platform, Url = link.Url, EntityType = "MusicalProject" });
                 }

                 // Handle removing social media links
                 if (src.SocialMediaLinkIdsToRemove != null && src.SocialMediaLinkIdsToRemove.Any())
                 {
                     dest.SocialMediaLinks.RemoveAll(sml => src.SocialMediaLinkIdsToRemove.Contains(sml.Id));
                 }

                 

                 // Handle updating social media links
                 foreach (var link in src.SocialMediaLinksToUpdate)
                 {
                     var existingLink = dest.SocialMediaLinks.FirstOrDefault(l => l.Id == link.Id);
                     if (existingLink != null)
                     {
                         existingLink.Platform = link.Platform;
                         existingLink.Url = link.Url;
                         existingLink.EntityType = "MusicalProject";
                     }
                 }
             });

        CreateMap<MP_SocialMediaLinkToAddDTO, SocialMediaLink>();
        CreateMap<MP_SocialMediaLinkToUpdateDTO, SocialMediaLink>();
    }
}


