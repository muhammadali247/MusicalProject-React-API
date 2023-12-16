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

public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
{
    public AlbumRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<List<Album>> GetAllDetailedAsync()
    {
        return await _dbContext.Albums.AsNoTracking()
                   .Include(a => a.MusicalProject)
                   .Include(a => a.MainCoverAlbumImage)
                   .Include(a => a.AlbumImages)
                   .Include(a => a.Songs)
                   .Include(a => a.AlbumGenres)
                   .ThenInclude(ag => ag.Genre)
                   .ToListAsync();
    }

    public async Task<Album> GetByIdDetailedAsync(Guid id)
    {
        return await _dbContext.Albums
                  .Include(a => a.MusicalProject)
                  .Include(a => a.MainCoverAlbumImage)
                  .Include(a => a.AlbumImages)
                  .Include(a => a.Songs)
                  .Include(a => a.AlbumGenres)
                  .ThenInclude(ag => ag.Genre)
                  .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AssignMainCoverImage(Guid albumId)
    {
        var album = await _dbContext.Albums.FindAsync(albumId);
        if (album == null) throw new Application.Exceptions.NotFoundException(nameof(Album), albumId);


        var mainCoverImage = album.AlbumImages.FirstOrDefault(img => img.IsMainCover);
        if (mainCoverImage == null) throw new InvalidOperationException("No main cover image found for this album.");

        album.MainCoverAlbumImageId = mainCoverImage.Id;
        album.MainCoverAlbumImage = mainCoverImage;
    }
}
