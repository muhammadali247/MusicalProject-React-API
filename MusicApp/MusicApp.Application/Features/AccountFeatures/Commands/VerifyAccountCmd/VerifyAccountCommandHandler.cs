using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.Application.DTOs.AccountDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.VerifyAccountCmd;

public class VerifyAccountCommandHandler : IRequestHandler<VerifyAccountCommand, string>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IValidator<VerifyAccountDTO> _verificationValidator;

    public VerifyAccountCommandHandler(UserManager<AppUser> userManager, IValidator<VerifyAccountDTO> verificationValidator)
    {
        _userManager = userManager;
        _verificationValidator = verificationValidator;
    }

    public async Task<string> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _verificationValidator.ValidateAsync(request.VerifyAccountDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);


        // Use the userId from the request to find the user
        AppUser user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) throw new BadRequestException(new string[] { "User ID is not found!" });


        // Check if the OTP matches and is not expired
        if (user.OTP != request.VerifyAccountDTO.Otp || user.OTPExpiryDate <= DateTime.Now)
        {
            throw new BadRequestException(new string[] { "Invalid OTP or OTP has expired." });
        }

        // Mark the email as confirmed
        user.EmailConfirmed = true;
        user.OTP = null;
        user.OTPExpiryDate = null;


        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new BadRequestException(result.Errors.Select(error => error.Description).ToArray());
        }

        return "Account verified successfully.";
    }
}