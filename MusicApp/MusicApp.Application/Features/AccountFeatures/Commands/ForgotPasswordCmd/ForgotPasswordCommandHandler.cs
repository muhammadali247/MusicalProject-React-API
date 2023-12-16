using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Application.DTOs.AccountDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.ForgotPasswordCmd;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, string>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IValidator<ForgotPasswordDTO> _forgotPasswordValidator;
    private readonly IEmailService _emailService;
    private readonly IFileService _fileService;
    private readonly IConfiguration _configuration;

    public ForgotPasswordCommandHandler(UserManager<AppUser> userManager, IValidator<ForgotPasswordDTO> forgotPasswordValidator, IEmailService emailService, IConfiguration configuration, IFileService fileService)
    {
        _userManager = userManager;
        _forgotPasswordValidator = forgotPasswordValidator;
        _emailService = emailService;
        _configuration = configuration;
        _fileService = fileService;
    }


    public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _forgotPasswordValidator.ValidateAsync(request.ForgotPasswordDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        var user = await _userManager.FindByEmailAsync(request.ForgotPasswordDTO.Email);
        if (user == null) throw new Exceptions.BadRequestException(new string[] { "No user associated with email address exists." });

        // Generate reset token
        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);


        // Generate Email using HTML Template
        string resetLink = $"{_configuration["FrontEndUrl"]}/auth/resetPassword?email={user.Email}&token={Uri.EscapeDataString(resetToken)}";
        string path = _configuration.GetValue<string>("ForgotPasswordTemplatePath");
        string body = string.Empty;

        body = _fileService.ReadFile(path, body);
        body = body.Replace("{{link}}", resetLink);
        body = body.Replace("{{firstname}}", user.Firstname); 
        body = body.Replace("{{lastname}}", user.Lastname); 
        string subject = "Password Reset Instructions"; 

        _emailService.Send(user.Email, subject, body);

        return "Reset password link has been sent to your email.";
    }
}
