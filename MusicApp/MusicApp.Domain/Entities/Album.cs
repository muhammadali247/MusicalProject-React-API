using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Album : BaseEntity
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }

    public Guid MusicalProjectId { get; set; }
    public MusicalProject MusicalProject { get; set; }

    public Guid? MainCoverAlbumImageId { get; set; }
    public AlbumImage? MainCoverAlbumImage { get; set; }

    public List<AlbumImage>? AlbumImages { get; set; } = new List<AlbumImage>();
    public List<AlbumGenre> AlbumGenres { get; set; } = new List<AlbumGenre>();
    public List<Song> Songs { get; set; } = new List<Song>();

}
