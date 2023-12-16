using AutoMapper;
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

namespace MusicApp.Application.Features.AccountFeatures.Commands.RegisterCmd;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IValidator<RegisterDTO> _createValidator;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly IFileService _fileService;
    private readonly IConfiguration _configuration;
    private readonly IOTPService _otpService;


    public RegisterCommandHandler(UserManager<AppUser> userManager, IValidator<RegisterDTO> createValidator, IMapper mapper, IEmailService emailService, IFileService fileService, IConfiguration configuration, IOTPService otpService)
    {
        _userManager = userManager;
        _createValidator = createValidator;
        _mapper = mapper;
        _emailService = emailService;
        _fileService = fileService;
        _configuration = configuration;
        _otpService = otpService;
    }

    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request.RegisterDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        AppUser user = await _userManager.FindByNameAsync(request.RegisterDTO.UserName);
        if (user != null) throw new Exceptions.BadRequestException(new string[] { "Username already exists." });

        var newUser = _mapper.Map<AppUser>(request.RegisterDTO);

        // Generate OTP and set expiry date
        var otp = _otpService.GenerateOTP();
        newUser.OTP = otp;
        newUser.OTPExpiryDate = DateTime.Now.AddMinutes(5);

        var result = await _userManager.CreateAsync(newUser, request.RegisterDTO.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToArray();
            throw new Exceptions.BadRequestException(errors);
        }

        // Email verification logic - Start
        string path = _configuration.GetValue<string>("EmailTemplatePath");
        string body = string.Empty;
        string subject = "Verify Email";

        body = _fileService.ReadFile(path, body);
        body = body.Replace("{{otp}}", newUser.OTP); 
        body = body.Replace("{{firstname}}", newUser.Firstname);
        body = body.Replace("{{lastname}}", newUser.Lastname);

        _emailService.Send(newUser.Email, subject, body);
        // Email verification logic - End


        var newUserId = newUser.Id;
        result = await _userManager.AddToRoleAsync(newUser, "Member");
        return newUserId;
    }
}
