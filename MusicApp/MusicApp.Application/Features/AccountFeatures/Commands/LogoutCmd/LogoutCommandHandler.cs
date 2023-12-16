using FluentValidation;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.LogoutCmd;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LogoutCommandHandler(IRefreshTokenRepository refreshTokenRepository, IUnitOfWork unitOfWork)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        if (request.UserId == null) throw new Exceptions.BadRequestException(new string[]{ "userId is required"});

        var existingRefreshToken = await _refreshTokenRepository.FindNonRevokedTokenByUserIdAsync(request.UserId);

        if (existingRefreshToken != null)
        {
            // Set the existing token as revoked
            existingRefreshToken.IsRevoked = true;

            // Update the existing token in the database
            await _refreshTokenRepository.UpdateAsync(existingRefreshToken.Id, existingRefreshToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
