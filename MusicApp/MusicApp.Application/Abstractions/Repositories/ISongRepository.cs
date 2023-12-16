using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Repositories;

public interface ISongRepository : IGenericRepository<Song>
{
    Task<List<Song>> GetAllDetailedAsync();
    Task<Song> GetByIdDetailedAsync(Guid id);
}
