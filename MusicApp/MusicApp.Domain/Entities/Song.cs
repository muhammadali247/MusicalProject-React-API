using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Song : BaseEntity
{
    public string Title { get; set; }
    public int DurationInSeconds { get; set; }
    public int? TrackOrderNumber { get; set; }

    public Guid? AlbumId { get; set; }
    public Album? Album { get; set; }

    public Lyrics? Lyrics { get; set; }
}
