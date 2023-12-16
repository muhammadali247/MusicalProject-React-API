using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Services;

public interface IAuthService
{
    Task<string> GenerateTokenAsync(AppUser user, IList<string> roles, TimeSpan tokenLifetime);
    Task<RefreshToken> GenerateRefreshTokenAsync(AppUser user, TimeSpan tokenLifetime, CancellationToken cancellationToken);

}
