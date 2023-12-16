using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }


    public Guid SongId { get; set; }
    public Song Song { get; set; }

    public Guid AlbumId { get; set; }
    public Album Album { get; set; }

    public Guid EventId { get; set; }
    public Event Event { get; set; }


    public string? UserId { get; set; }
    public AppUser User { get; set; }
}
