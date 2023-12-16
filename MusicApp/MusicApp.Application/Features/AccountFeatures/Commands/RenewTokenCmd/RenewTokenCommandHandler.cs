using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Application.DTOs.AccountDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.RenewTokenCmd;

public class RenewTokenCommandHandler : IRequestHandler<RenewTokenCommand, string>
{
    private readonly IAuthService _authService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IValidator<RenewTokenDTO> _renewTokenValidator;
    private readonly UserManager<AppUser> _userManager;

    public RenewTokenCommandHandler(IAuthService authService, IRefreshTokenRepository refreshTokenRepository, IValidator<RenewTokenDTO> renewTokenValidator, UserManager<AppUser> userManager)
    {
        _authService = authService;
        _refreshTokenRepository = refreshTokenRepository;
        _renewTokenValidator = renewTokenValidator;
        _userManager = userManager;
    }

    public async Task<string> Handle(RenewTokenCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await _renewTokenValidator.ValidateAsync(request.RenewTokenDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        // Validate and retrieve the refresh token
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RenewTokenDTO.Token);

        if (refreshToken == null || refreshToken.Expires < DateTime.Now || refreshToken.IsRevoked)
        {
            // Refresh token is invalid, expired, or revoked
            throw new BadRequestException(new string[] { "Invalid refresh token." });
        }

        // Retrieve the user associated with the refresh token
        var user = await _userManager.FindByIdAsync(refreshToken.UserId);

        if (user == null)
        {
            // User not found
            throw new BadRequestException(new string[] { "User not found." });
        }

        // Generate a new access token
        var roles = await _userManager.GetRolesAsync(user);
        var accessTokenLifetime = TimeSpan.FromMinutes(5);
        var accessToken = await _authService.GenerateTokenAsync(user, roles, accessTokenLifetime);

        return accessToken;
    }
}
