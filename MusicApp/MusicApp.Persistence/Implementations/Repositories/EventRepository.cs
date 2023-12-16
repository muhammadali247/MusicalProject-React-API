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

public class EventRepository : GenericRepository<Event>, IEventRepository
{
    public EventRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<List<Event>> GetAllDetailedAsync()
    {
        return await _dbContext.Events.AsNoTracking()
            .Include(ev => ev.MusicalProjectEvents)
            .ThenInclude(mpe => mpe.MusicalProject)
            .Include(ev => ev.Tickets)
            .ToListAsync();
    }

    public async Task<Event> GetByIdDetailedAsync(Guid id)
    {
        return await _dbContext.Events.AsNoTracking()
           .Include(ev => ev.MusicalProjectEvents)
           .ThenInclude(mpe => mpe.MusicalProject)
           .Include(ev => ev.Tickets)
           .FirstOrDefaultAsync(ev => ev.Id == id);
    }
}
