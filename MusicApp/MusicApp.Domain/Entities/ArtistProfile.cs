using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class ArtistProfile : BaseEntity
{
    public string Biography { get; set; }
    public string WebsiteUrl { get; set; }

    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; }

    public Guid UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}
