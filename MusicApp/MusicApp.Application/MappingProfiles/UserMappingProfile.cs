using AutoMapper;
using MusicApp.Application.DTOs.UserDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<AppUser, UserViewDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Firstname))
            .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom(src => BuildImageUrl(src.UserProfile.ProfileImageUrl)))
            .ForMember(dest => dest.Roles, opt => opt.Ignore()); // Ignored for now
    }


    private string BuildImageUrl(string fileName)
    {
        return $"/images/users/{fileName}";
    }
}
