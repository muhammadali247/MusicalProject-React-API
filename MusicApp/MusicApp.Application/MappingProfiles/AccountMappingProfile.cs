using AutoMapper;
using MusicApp.Application.DTOs.AccountDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.MappingProfiles;

public class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<RegisterDTO, AppUser>()
              .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Firstname))
              .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
              .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
              .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore());
    }
}
