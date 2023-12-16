using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Repositories;

public interface IRefreshTokenRepository : IGenericRepository<RefreshToken> 
{
    Task<RefreshToken> FindNonRevokedTokenByUserIdAsync(string userId);
    Task<RefreshToken> GetByTokenAsync(string token);
}
