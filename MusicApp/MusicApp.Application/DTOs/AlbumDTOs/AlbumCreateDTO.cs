using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.AlbumDTOs;

public class AlbumCreateDTO
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public Guid MusicalProjectId { get; set; }
    public List<AlbumImageToAddDTO> AlbumImages { get; set; } = new List<AlbumImageToAddDTO>();
    public List<Guid> GenreIds { get; set; } = new List<Guid>();
    public List<SongToAddDTO> Songs { get; set; } = new List<SongToAddDTO>();
}

public class AlbumImageToAddDTO
{
    public string ImageUrl { get; set; }
    public bool IsMainCover { get; set; }
}
public class SongToAddDTO
{
    public string Title { get; set; }
    public int DurationInSeconds { get; set; }
}
