﻿using FluentValidation;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.AccountValidators;

public class ResetPasswordDTOValidator : AbstractValidator<ResetPasswordDTO>
{
    public ResetPasswordDTOValidator()
    {
        RuleFor(x => x.Email)
              .NotEmpty().WithMessage("Email is required")
              .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Token is required");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("New password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");

        RuleFor(x => x.ConfirmPassword)
           .Equal(x => x.NewPassword)
           .WithMessage("Passwords must match");
    }
}
