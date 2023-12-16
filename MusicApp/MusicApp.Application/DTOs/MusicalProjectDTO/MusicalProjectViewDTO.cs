using MusicApp.Domain.Entities;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.MusicalProjectDTO;

public class MusicalProjectViewDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? DateFounded { get; set; }
    public DateTime? DateCanceled { get; set; }
    public List<string> GenreNames { get; set; } = new List<string>();
    public List<string> ArtistNames { get; set; } = new List<string>();
    public List<string>? SocialMediaLinkUrls { get; set; } = new List<string>();
    public List<string> AlbumTitles { get; set; } = new List<string>();
    public ProjectType Type { get; set; }
}
