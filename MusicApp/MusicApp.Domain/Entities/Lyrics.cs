using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Lyrics : BaseEntity
{
    public string Content { get; set; }
    public string? Author { get; set; }

    public Guid SongId { get; set; }
    public Song Song { get; set; }
}
