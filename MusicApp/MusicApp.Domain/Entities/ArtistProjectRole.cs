using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class ArtistProjectRole : BaseEntity
{
    public Guid MusicalRoleId { get; set; }
    public MusicalRole MusicalRole { get; set; }

    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; }

    public Guid MusicalProjectId { get; set; }
    public MusicalProject MusicalProject { get; set; }

}
