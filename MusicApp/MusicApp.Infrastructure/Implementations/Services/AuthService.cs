using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Implementations.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IConfiguration config, IRefreshTokenRepository refreshTokenRepository, IUnitOfWork unitOfWork)
    {
        _config = config;
        _refreshTokenRepository = refreshTokenRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RefreshToken> GenerateRefreshTokenAsync(AppUser user, TimeSpan tokenLifetime, CancellationToken cancellationToken = default)
    {
        // Find an existing non-revoked refresh token for the user
        var existingRefreshToken = await _refreshTokenRepository.FindNonRevokedTokenByUserIdAsync(user.Id);

        if (existingRefreshToken != null)
        {
            // Set the existing token as revoked
            existingRefreshToken.IsRevoked = true;

            // Update the existing token in the database
            await _refreshTokenRepository.UpdateAsync(existingRefreshToken.Id, existingRefreshToken);
        }

        // Generate a new refresh token string (e.g., a random string)
        string refreshTokenString = GenerateRefreshTokenString();

        // Create a new RefreshToken entity
        var refreshToken = new RefreshToken
        {
            Token = refreshTokenString,
            Expires = DateTime.Now.Add(tokenLifetime),
            UserId = user.Id
        };

        // Store the new refresh token in the database
        await _refreshTokenRepository.CreateAsync(refreshToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return refreshToken;
    }

    public async Task<string> GenerateTokenAsync(AppUser user, IList<string> roles, TimeSpan tokenLifetime)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim("Firstname", user.Firstname ?? ""),  
                new Claim("Lastname", user.Lastname ?? ""),  
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        // Add roles to claims
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
               issuer: _config["JWT:Issuer"],
               audience: _config["JWT:Audience"],
               claims: claims,
               expires: DateTime.Now.Add(tokenLifetime),
               signingCredentials: creds
           );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshTokenString(int length = 64)
    {
        const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] tokenChars = new char[length];
        byte[] randomBytes = new byte[length];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        for (int i = 0; i < length; i++)
        {
            int index = randomBytes[i] % allowedChars.Length;
            tokenChars[i] = allowedChars[index];
        }

        return new string(tokenChars);
    }
}
