using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class UserProfile : BaseEntity
{
    public string Bio { get; set; }
    public string ProfileImageUrl { get; set; }
    public string DisplayedName { get; set; }

    public AppUser User { get; set; }
    public string UserId { get; set; }
    public ArtistProfile? ArtistProfile { get; set; }
    public List<UserFavoriteGenre>? UserFavoriteGenres { get; set; } = new List<UserFavoriteGenre>();
    public List<UserFavoriteArtist>? UserFavoriteArtists { get; set; } = new List<UserFavoriteArtist>();
    public List<UserFavoriteMusicalProject>? UserFavoriteMusicalProjects { get; set; } = new List<UserFavoriteMusicalProject>();
    public List<SocialMediaLink>? SocialMediaLinks { get; set; } = new List<SocialMediaLink>();

}
