using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.ResendOTPCmd;

public class ResendOTPCommandHandler : IRequestHandler<ResendOTPCommand, string>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;
    private readonly IFileService _fileService;
    private readonly IOTPService _otpService;
    public ResendOTPCommandHandler(UserManager<AppUser> userManager, IEmailService emailService, IConfiguration configuration, IFileService fileService, IOTPService otpService)
    {
        _userManager = userManager;
        _emailService = emailService;
        _configuration = configuration;
        _fileService = fileService;
        _otpService = otpService;
    }



    public async Task<string> Handle(ResendOTPCommand request, CancellationToken cancellationToken)
    {
        // Use the userId from the request to find the user
        AppUser user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) throw new BadRequestException(new string[] { "User ID is not found!" });

        // Generate a new OTP and set expiry date
        var newOtp = _otpService.GenerateOTP();
        user.OTP = newOtp;
        user.OTPExpiryDate = DateTime.Now.AddMinutes(5);

        // Update the user with new OTP information
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new BadRequestException(result.Errors.Select(error => error.Description).ToArray());
        }

        // Email logic to resend OTP
        string path = _configuration.GetValue<string>("EmailTemplatePath");
        string body = string.Empty;
        string subject = "Resend OTP";

        body = _fileService.ReadFile(path, body);
        body = body.Replace("{{otp}}", newOtp);
        body = body.Replace("{{firstname}}", user.Firstname);
        body = body.Replace("{{lastname}}", user.Lastname);

        _emailService.Send(user.Email, subject, body);

        return "OTP resent successfully.";
    }
}

