using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Repositories;

public interface IAlbumRepository : IGenericRepository<Album>
{
    Task<List<Album>> GetAllDetailedAsync();
    Task<Album> GetByIdDetailedAsync(Guid id);
    Task AssignMainCoverImage(Guid albumId);
}
