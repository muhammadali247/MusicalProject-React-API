using FluentValidation;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.AccountValidators;

public class RenewTokenDTOValidator : AbstractValidator<RenewTokenDTO>
{
    public RenewTokenDTOValidator()
    {
        RuleFor(renewToken => renewToken.Token)
          .NotEmpty()
          .WithMessage("Token is required");
    }
}
