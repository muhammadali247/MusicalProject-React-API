using Microsoft.EntityFrameworkCore;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Domain.Entities;
using MusicApp.Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.Implementations.Repositories;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<RefreshToken> FindNonRevokedTokenByUserIdAsync(string userId)
    {
        var refreshToken = await _dbContext.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == userId && !t.IsRevoked);
        return refreshToken;
    }

    public async Task<RefreshToken> GetByTokenAsync(string token)
    {
        var refreshToken = await _dbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token);
        return refreshToken;
    }
}
