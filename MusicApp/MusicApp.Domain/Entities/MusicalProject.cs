using MusicApp.Domain.Common;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class MusicalProject : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? DateFounded { get; set; }
    public DateTime? DateCanceled { get; set; }
    public ProjectType? Type { get; set; }


    public List<MusicalProjectGenre> MusicalProjectGenres { get; set; } = new List<MusicalProjectGenre>();
    public List<ArtistMusicalProject> ArtistMusicalProjects { get; set; } = new List<ArtistMusicalProject>();
    public List<SocialMediaLink>? SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    public List<Album>? Albums { get; set; } = new List<Album>();
    public List<MusicalProjectEvent>? MusicalProjectEvents { get; set; } = new List<MusicalProjectEvent>();
    public List<UserFavoriteMusicalProject> UserFavoriteMusicalProjects { get; set; } = new List<UserFavoriteMusicalProject>();

}
