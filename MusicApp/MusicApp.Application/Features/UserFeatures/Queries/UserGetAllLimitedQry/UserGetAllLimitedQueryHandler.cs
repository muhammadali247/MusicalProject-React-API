using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.UserDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.UserFeatures.Queries.UserGetAllLimitedQry;

public class UserGetAllLimitedQueryHandler : IRequestHandler<UserGetAllLimitedQuery, List<UserViewDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;


    public UserGetAllLimitedQueryHandler(IUserRepository userRepository, IMapper mapper, UserManager<AppUser> userManager)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<List<UserViewDTO>> Handle(UserGetAllLimitedQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersLimitedWithProfileByIdAsync();

        var userViewDTOs = users.Select(user => _mapper.Map<UserViewDTO>(user)).ToList();

        // Adding roles to UserViewDTO
        foreach (var userViewDTO in userViewDTOs)
        {
            var user = users.First(u => u.Id == userViewDTO.Id);
            var roles = await _userManager.GetRolesAsync(user);
            userViewDTO.Roles = roles.ToList();
        }

        return userViewDTOs;
    }
}
