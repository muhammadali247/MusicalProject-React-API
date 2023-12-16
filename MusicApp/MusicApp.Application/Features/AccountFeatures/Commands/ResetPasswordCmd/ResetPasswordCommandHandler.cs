using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.Application.DTOs.AccountDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.ResetPasswordCmd;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, string>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IValidator<ResetPasswordDTO> _resetPasswordValidator;

    public ResetPasswordCommandHandler(UserManager<AppUser> userManager, IValidator<ResetPasswordDTO> resetPasswordValidator)
    {
        _userManager = userManager;
        _resetPasswordValidator = resetPasswordValidator;
    }

    public async Task<string> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _resetPasswordValidator.ValidateAsync(request.ResetPasswordDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        var user = await _userManager.FindByEmailAsync(request.ResetPasswordDTO.Email);
        if (user == null) throw new Exceptions.BadRequestException(new string[] { "Invalid request" });

        var result = await _userManager.ResetPasswordAsync(user, request.ResetPasswordDTO.Token, request.ResetPasswordDTO.NewPassword);

        if (!result.Succeeded)
        {
            throw new Exceptions.BadRequestException(result.Errors.Select(error => error.Description).ToArray());
        }

        return "Password has been reset successfully.";
    }
}
