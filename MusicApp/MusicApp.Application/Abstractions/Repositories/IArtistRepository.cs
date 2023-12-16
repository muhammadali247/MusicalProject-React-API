using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Repositories;

public interface IArtistRepository : IGenericRepository<Artist>
{
    Task<List<Artist>> GetAllDetailedAsync();
    Task<Artist> GetByIdDetailedAsync(Guid id);
}



