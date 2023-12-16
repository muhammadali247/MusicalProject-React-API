using FluentValidation;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.AccountValidators;

public class LoginDTOValidator : AbstractValidator<LoginDTO>
{
    public LoginDTOValidator()
    {
        RuleFor(login => login.UserNameOrEmail)
               .NotEmpty()
               .WithMessage("Username or Email is required")
               .MaximumLength(100)
               .WithMessage("Username or Email cannot be more than 100 characters");

        RuleFor(login => login.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}
