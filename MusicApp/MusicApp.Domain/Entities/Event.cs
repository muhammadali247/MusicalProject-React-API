using MusicApp.Domain.Common;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Event : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? EventDate { get; set; }
    public int? EventDuration { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? LiveStreamUrl { get; set; }
    public EventStatus? Status { get; set; }
    public string? Location { get; set; }

    public List<MusicalProjectEvent>? MusicalProjectEvents { get; set; } = new List<MusicalProjectEvent>();
    public List<Ticket>? Tickets { get; set; } = new List<Ticket>();
    //public List<Album> FeaturedAlbums { get; set; } = new List<Album>();
    //public List<Song> FeaturedSongs { get; set; } = new List<Song>();
}
