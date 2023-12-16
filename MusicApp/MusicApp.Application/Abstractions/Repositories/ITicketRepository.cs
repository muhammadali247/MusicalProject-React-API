using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Repositories;

public interface ITicketRepository : IGenericRepository<Ticket>
{
    Task<List<Ticket>> GetAllDetailedAsync();
    Task<Ticket> GetByIdDetailedAsync(Guid id);
}
