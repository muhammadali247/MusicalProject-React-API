using AutoMapper;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.MappingProfiles;

public class ArtistMappingProfile : Profile
{
    public ArtistMappingProfile()
    {
        CreateMap<Artist, ArtistViewDTO>()
              .ForMember(dest => dest.ProjectNames, opt => opt.MapFrom(src => src.ArtistMusicalProjects.Select(amp => amp.MusicalProject.Name).ToList())).ReverseMap();

        CreateMap<ArtistCreateDTO, Artist>()
          .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.ArtistName))
          .ForMember(dest => dest.ArtistMusicalProjects, opt => opt.MapFrom(src => src.ProjectIds.Select(projectId => new ArtistMusicalProject { MusicalProjectId = projectId })));

        CreateMap<ArtistUpdateDTO, Artist>()
             .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.ArtistName))
             .ForMember(dest => dest.ArtistMusicalProjects, opt => opt.Ignore())
            .AfterMap((src, dest) =>
            {
                // Update ArtistMusicalProjects

                // Add new ArtistMusicalProjects based on ProjectIdsToAdd
                if (src.ProjectIdsToAdd != null && src.ProjectIdsToAdd.Any())
                {
                    foreach (var projectId in src.ProjectIdsToAdd)
                    {
                        // Check if the ArtistMusicalProject with the given MusicalProjectId already exists
                        if (!dest.ArtistMusicalProjects.Any(amp => amp.MusicalProjectId == projectId))
                        {
                            dest.ArtistMusicalProjects.Add(new ArtistMusicalProject { MusicalProjectId = projectId });
                        }
                    }
                }

                // Remove ArtistMusicalProjects based on ProjectIdsToRemove
                if (src.ProjectIdsToRemove != null && src.ProjectIdsToRemove.Any())
                {
                    dest.ArtistMusicalProjects.RemoveAll(amp => src.ProjectIdsToRemove.Contains(amp.MusicalProjectId));
                }
            });

        CreateMap<Artist, ArtistFullDetailsDTO>()
            .ForMember(dest => dest.AssociatedProjects, opt => opt.MapFrom(src => src.ArtistMusicalProjects));

        CreateMap<ArtistMusicalProject, ArtistAssociatedProjectDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MusicalProjectId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MusicalProject.Name));

        //CreateMap<ArtistUpdateDTO, Artist>()
        //  .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.ArtistName))
        //  .ForMember(dest => dest.Projects, opt => opt.Ignore())
        //  .AfterMap((src, dest) =>
        //  {
        //      // Get the list of existing project IDs associated with the artist
        //      var existingProjectIds = dest.Projects.Select(p => p.Id).ToList();

        //      // Add the ProjectIdsToAdd to the Projects list (only if they are not already associated)
        //      if (src.ProjectIdsToAdd != null && src.ProjectIdsToAdd.Any())
        //      {
        //          var newProjectIdsToAdd = src.ProjectIdsToAdd.Except(existingProjectIds).ToList();
        //          dest.Projects.AddRange(newProjectIdsToAdd.Select(id => new MusicalProject { Id = id }));
        //      }

        //      // Remove the ProjectIdsToRemove from the Projects list
        //      if (src.ProjectIdsToRemove != null && src.ProjectIdsToRemove.Any())
        //      {
        //          dest.Projects.RemoveAll(p => src.ProjectIdsToRemove.Contains(p.Id));
        //      }
        //  });
    }

    //public class ArtistMappingProfile : Profile
    //{
    //    public ArtistMappingProfile()
    //    {
    //        CreateMap<Artist, ArtistViewDTO>()
    //            .ForMember(dest => dest.Username, opt => opt.MapFrom<UsernameResolver>());
    //    }
    //}

    //public class UsernameResolver : IValueResolver<Artist, ArtistViewDTO, string?>
    //{
    //    private readonly IAppUserRepository _appUserRepository; // Assuming you have a repository for AppUser

    //    public UsernameResolver(IAppUserRepository appUserRepository)
    //    {
    //        _appUserRepository = appUserRepository;
    //    }

    //    public string? Resolve(Artist source, ArtistViewDTO destination, string? destMember, ResolutionContext context)
    //    {
    //        if (string.IsNullOrEmpty(source.UserId))
    //            return null;

    //        // Retrieve the AppUser by UserId and get the UserName
    //        var appUser = _appUserRepository.GetUserById(source.UserId);
    //        return appUser?.UserName;
    //    }
    //}
}
