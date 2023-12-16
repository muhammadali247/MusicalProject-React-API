using MusicApp.Domain.Common;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class SocialMediaLink : BaseEntity
{
    public LinkPlatform Platform { get; set; }
    public string Url { get; set; }

    public Guid? ArtistId { get; set; }
    public Guid? UserProfileId { get; set; }
    public Guid? MusicalProjectId { get; set; }

    public  Artist Artist { get; set; }
    public  UserProfile UserProfile { get; set; }
    public  MusicalProject MusicalProject { get; set; }

    public string? EntityType { get; set; }
}
