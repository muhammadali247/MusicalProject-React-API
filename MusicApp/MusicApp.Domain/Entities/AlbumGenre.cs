using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class AlbumGenre : BaseEntity
{
    public Guid AlbumId { get; set; }
    public Album Album { get; set; }

    public Guid GenreId { get; set; }
    public Genre Genre { get; set; }
}
