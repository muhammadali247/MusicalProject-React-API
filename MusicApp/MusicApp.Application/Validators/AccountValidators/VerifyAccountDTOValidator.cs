using FluentValidation;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.AccountValidators;

public class VerifyAccountDTOValidator : AbstractValidator<VerifyAccountDTO>
{
    public VerifyAccountDTOValidator()
    {
        RuleFor(verifyAccount => verifyAccount.Otp)
             .NotEmpty()
             .WithMessage("Otp is required");
    }
}
