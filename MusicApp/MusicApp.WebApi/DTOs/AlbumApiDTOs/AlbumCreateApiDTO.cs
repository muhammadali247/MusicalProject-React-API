namespace MusicApp.WebApi.DTOs.AlbumApiDTOs;

public class AlbumCreateApiDTO
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public Guid MusicalProjectId { get; set; }
    public List<AlbumImageToAddApiDTO> AlbumImages { get; set; } = new List<AlbumImageToAddApiDTO>();
    public List<SongToAddApiDTO> Songs { get; set; } = new List<SongToAddApiDTO>();
    public List<Guid> GenreIds { get; set; } = new List<Guid>();
}

public class AlbumImageToAddApiDTO
{
    public IFormFile ImageFile { get; set; }
    public bool IsMainCover { get; set; } = false;
}

public class SongToAddApiDTO
{
    public string Title { get; set; }
    public int DurationInSeconds { get; set; }
}
