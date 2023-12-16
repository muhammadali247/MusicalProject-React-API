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

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<AppUser>> GetAllUsersLimitedWithProfileByIdAsync()
    {
        return await _dbContext.Users.AsNoTracking()
           .Include(u => u.UserProfile)
           .ToListAsync();
    }

    public async Task<AppUser> GetUserLimitedWithProfileByIdAsync(string id)
    {
        return await _dbContext.Users
           .Include(u => u.UserProfile)
           .FirstOrDefaultAsync(u => u.Id == id);
    }
}
