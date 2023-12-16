using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Repositories;

public interface IMusicalProjectRepository : IGenericRepository<MusicalProject>
{
    Task<List<MusicalProject>> GetAllDetailedAsync();
    Task<MusicalProject> GetByIdDetailedAsync(Guid id);
}
