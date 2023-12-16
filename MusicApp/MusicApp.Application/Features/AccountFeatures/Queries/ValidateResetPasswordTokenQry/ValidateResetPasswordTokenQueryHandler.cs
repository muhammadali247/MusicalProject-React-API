using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Queries.ValidateResetPasswordTokenQry;

public class ValidateResetPasswordTokenQueryHandler : IRequestHandler<ValidateResetPasswordTokenQuery, string>
{
    private readonly UserManager<AppUser> _userManager;

    public ValidateResetPasswordTokenQueryHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(ValidateResetPasswordTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new Exceptions.BadRequestException(new string[] { "Invalid request" });
        }

        var decodedToken = Uri.UnescapeDataString(request.Token);
        var isValid = await _userManager.VerifyUserTokenAsync(user, "Default", "ResetPassword", decodedToken);

        if (!isValid)
        {
            throw new Exceptions.BadRequestException(new string[] { "Invalid token" });
        }

        return "Token is valid";
    }
}
