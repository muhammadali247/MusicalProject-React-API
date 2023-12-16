using MusicApp.Domain.Entities;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.MusicalProjectDTO;

public class MusicalProjectCreateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? DateFounded { get; set; }
    public DateTime? DateCanceled { get; set; }
    public List<Guid> ArtistIds { get; set; } = new List<Guid>();
    public List<Guid> GenreIds { get; set; } = new List<Guid>();
    public List<MP_SocialMediaLinkDTO>? SocialMediaLinks { get; set; } = new List<MP_SocialMediaLinkDTO>();
    public ProjectType? Type { get; set; }

}

public class MP_SocialMediaLinkDTO
{
    public LinkPlatform Platform { get; set; }
    public string Url { get; set; }
}


