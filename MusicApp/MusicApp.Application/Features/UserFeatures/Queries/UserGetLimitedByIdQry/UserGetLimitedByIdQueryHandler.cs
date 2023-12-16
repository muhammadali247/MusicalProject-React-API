using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.UserDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.UserFeatures.Queries.UserGetLimitedByIdQry;

public class UserGetLimitedByIdQueryHandler : IRequestHandler<UserGetLimitedByIdQuery, UserViewDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public UserGetLimitedByIdQueryHandler(IUserRepository userRepository, IMapper mapper, UserManager<AppUser> userManager)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
    }


    public async Task<UserViewDTO> Handle(UserGetLimitedByIdQuery request, CancellationToken cancellationToken)
    {
        var returnedUser = await _userRepository.GetUserLimitedWithProfileByIdAsync(request.Id);
        if (returnedUser == null) throw new NotFoundException(nameof(AppUser), request.Id);

        var userDTO = _mapper.Map<UserViewDTO>(returnedUser);

        // Adding roles to UserDetailDTO
        var roles = await _userManager.GetRolesAsync(returnedUser);
        userDTO.Roles = roles.ToList();

        return userDTO;
    }
}
