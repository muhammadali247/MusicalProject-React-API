using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class ArtistMusicalProject : BaseEntity
{
    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; }

    public Guid MusicalProjectId { get; set; }
    public MusicalProject MusicalProject { get; set; }
}
