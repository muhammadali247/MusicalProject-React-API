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

public class SongRepository : GenericRepository<Song>, ISongRepository
{
    public SongRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<List<Song>> GetAllDetailedAsync()
    {
        return await _dbContext.Songs.AsNoTracking()
            .Include(s => s.Lyrics)
            .Include(s => s.Album)
            .ToListAsync();
    }

    public async Task<Song> GetByIdDetailedAsync(Guid id)
    {
        return await _dbContext.Songs.AsNoTracking()
           .Include(s => s.Lyrics)
           .Include(s => s.Album)
           .FirstOrDefaultAsync();
    }
}
