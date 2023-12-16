using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.MusicalProjectDTO;

public class MusicalProjectUpdateDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? DateFounded { get; set; }
    public DateTime? DateCanceled { get; set; }
    public List<Guid> ArtistIdsToAdd { get; set; } = new List<Guid>();
    public List<Guid> ArtistIdsToRemove { get; set; } = new List<Guid>();
    public List<Guid> GenreIdsToAdd { get; set; } = new List<Guid>();
    public List<Guid> GenreIdsToRemove { get; set; } = new List<Guid>();
    public List<MP_SocialMediaLinkToAddDTO> SocialMediaLinksToAdd { get; set; } = new List<MP_SocialMediaLinkToAddDTO>();
    public List<Guid> SocialMediaLinkIdsToRemove { get; set; } = new List<Guid>();
    public List<MP_SocialMediaLinkToUpdateDTO> SocialMediaLinksToUpdate { get; set; } = new List<MP_SocialMediaLinkToUpdateDTO>();
    public ProjectType? Type { get; set; }

}

public class MP_SocialMediaLinkToAddDTO
{
    public LinkPlatform Platform { get; set; }
    public string Url { get; set; }
}

public class MP_SocialMediaLinkToUpdateDTO : MP_SocialMediaLinkToAddDTO
{
    public Guid Id { get; set; }
}
