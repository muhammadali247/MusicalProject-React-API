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

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    public TicketRepository(AppDbContext dbContext) : base(dbContext) { }
    
    

    public async Task<List<Ticket>> GetAllDetailedAsync()
    {
        return await _dbContext.Tickets.AsNoTracking()
            .Include(t => t.Event)
            .Include(t => t.OrderItem)
            .ToListAsync();
    }

    public async Task<Ticket> GetByIdDetailedAsync(Guid id)
    {
        return await _dbContext.Tickets.AsNoTracking()
           .Include(t => t.Event)
           .Include(t => t.OrderItem)
           .FirstOrDefaultAsync();
    }
}
