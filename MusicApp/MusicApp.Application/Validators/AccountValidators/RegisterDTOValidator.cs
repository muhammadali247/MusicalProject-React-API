﻿using FluentValidation;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.AccountValidators;

public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
{
    public RegisterDTOValidator()
    {
        RuleFor(register => register.Firstname)
            .NotEmpty()
            .WithMessage("Firstname is required")
            .MaximumLength(100)
            .WithMessage("Firstname cannot be more than 100 characters");

        RuleFor(register => register.Lastname)
            .NotEmpty()
            .WithMessage("Lastname is required")
            .MaximumLength(100)
            .WithMessage("Lastname cannot be more than 100 characters");

        RuleFor(register => register.PhoneNumber)
            .NotEmpty()
            .WithMessage("PhoneNumber is required!");

        RuleFor(register => register.UserName)
            .NotEmpty()
            .WithMessage("Username is required")
            .MaximumLength(100)
            .WithMessage("Username cannot be more than 100 characters");

        RuleFor(register => register.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid Email Address");

        RuleFor(register => register.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .MaximumLength(20).WithMessage("Password cannot exceed 20 characters.");

        RuleFor(register => register.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm Password is required")
            .Equal(register => register.Password)
            .WithMessage("Password and Confirm Password must match");
    }
}
