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

public class MusicalProjectRepository : GenericRepository<MusicalProject>, IMusicalProjectRepository
{
    public MusicalProjectRepository(AppDbContext dbContext) : base(dbContext) { }
   

    public async Task<List<MusicalProject>> GetAllDetailedAsync()
    {
        return await _dbContext.MusicalProjects.AsNoTracking()
                  .Include(mp => mp.ArtistMusicalProjects)
                  .ThenInclude(amp => amp.Artist)
                  .Include(mp => mp.MusicalProjectGenres)
                  .ThenInclude(g => g.Genre)
                  .Include(mp => mp.Albums)
                  .Include(mp => mp.SocialMediaLinks)
                  .ToListAsync();
    }

    public async Task<MusicalProject> GetByIdDetailedAsync(Guid id)
    {
        return await _dbContext.MusicalProjects
                .Include(mp => mp.ArtistMusicalProjects)
                .ThenInclude(amp => amp.Artist)
                .Include(mp => mp.MusicalProjectGenres)
                .ThenInclude(g => g.Genre)
                .Include(mp => mp.Albums)
                .Include(mp => mp.SocialMediaLinks)
                .FirstOrDefaultAsync(mp => mp.Id == id);
    }
}
