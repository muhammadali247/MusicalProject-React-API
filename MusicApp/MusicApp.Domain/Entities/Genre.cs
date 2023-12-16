using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }
    public string? ParentName { get; set; }
    public Guid? ParentGenreId { get; set; } 
    public Genre? ParentGenre { get; set; }   
    public ICollection<Genre>? SubGenres { get; set; } = new List<Genre>(); 

    public List<MusicalProjectGenre> MusicalProjectGenres { get; set; } = new List<MusicalProjectGenre>();
    public List<AlbumGenre> AlbumGenres { get; set; } = new List<AlbumGenre>();
    public List<UserFavoriteGenre>? UserFavoriteGenres { get; set; } = new List<UserFavoriteGenre>();
}
