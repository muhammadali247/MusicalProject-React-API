using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Application.DTOs.AccountDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.LoginCmd;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IValidator<LoginDTO> _loginValidator;
    private readonly IAuthService _authService;



    public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IValidator<LoginDTO> loginValidator, IAuthService authService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _loginValidator = loginValidator;
        _authService = authService;
    }


    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _loginValidator.ValidateAsync(request.LoginDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        AppUser user = await _userManager.FindByNameAsync(request.LoginDTO.UserNameOrEmail)
                       ?? await _userManager.FindByEmailAsync(request.LoginDTO.UserNameOrEmail);

        if (user == null) throw new BadRequestException(new string[] { "Username or email is wrong!" });

        var result = await _signInManager.PasswordSignInAsync(user, request.LoginDTO.Password, request.LoginDTO.RememberMe, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var refreshTokenLifetime = request.LoginDTO.RememberMe ? TimeSpan.FromDays(30) : TimeSpan.FromMinutes(42);
            var accessTokenLifetime = TimeSpan.FromMinutes(5);

            // Generate the refresh token
            var refreshToken = await _authService.GenerateRefreshTokenAsync(user, refreshTokenLifetime, cancellationToken);

            // Generate the access token
            var accessToken = await _authService.GenerateTokenAsync(user, roles, accessTokenLifetime);

            return new LoginResponse(accessToken, refreshToken);
        }
        else
        {
            var failureMessage = result.IsLockedOut ? "Your account is locked." : "Invalid username or password.";
            throw new BadRequestException(new string[] { failureMessage });
        }
    }
}
