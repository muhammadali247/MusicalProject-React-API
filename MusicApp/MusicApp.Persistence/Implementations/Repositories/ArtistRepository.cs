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

public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
{
    public ArtistRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<List<Artist>> GetAllDetailedAsync()
    {
        return await _dbContext.Artists.AsNoTracking()
                   .Include(a => a.ArtistMusicalProjects)
                   .ThenInclude(amp => amp.MusicalProject)
                   .ToListAsync();
    }

    public async Task<Artist> GetByIdDetailedAsync(Guid id)
    {
        return await _dbContext.Artists
                  .Include(a => a.ArtistMusicalProjects)
                  .ThenInclude(amp => amp.MusicalProject)
                  .FirstOrDefaultAsync(a => a.Id == id);
    }
}
