using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.AlbumDTOs;

public class AlbumViewDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string MusicalProjectName { get; set; }
    public string MainCoverAlbumImageUrl { get; set; }
    public List<string> ImageUrls { get; set; }
    public List<string> GenreNames { get; set; }
    public List<string> SongTitles { get; set; }
}
