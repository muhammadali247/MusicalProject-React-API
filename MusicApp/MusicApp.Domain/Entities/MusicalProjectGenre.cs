using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class MusicalProjectGenre : BaseEntity
{
    public Guid MusicalProjectId { get; set; }
    public MusicalProject MusicalProject { get; set; }

    public Guid GenreId { get; set; }
    public Genre Genre { get; set; }
}
