using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Artist : BaseEntity
{
    public string ArtistName { get; set; }

    public List<ArtistMusicalProject> ArtistMusicalProjects { get; set; } = new List<ArtistMusicalProject>();

    public ArtistProfile? Profile { get; set; }
    public List<UserFavoriteArtist>? UserFavoriteArtists { get; set; } = new List<UserFavoriteArtist>();
}
