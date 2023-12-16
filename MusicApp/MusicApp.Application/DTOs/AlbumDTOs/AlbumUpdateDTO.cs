using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.AlbumDTOs;

public class AlbumUpdateDTO
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public Guid MusicalProjectId { get; set; }
    public Guid MainCoverAlbumImageId { get; set; }
    public List<string> ExistingAlbumImages { get; set; }
    public List<string> NewAlbumImages { get; set; }
    public List<Guid> GenreIds { get; set; }
    public List<Guid> SongIds { get; set; }
}
