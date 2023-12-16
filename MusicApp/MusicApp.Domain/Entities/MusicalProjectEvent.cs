using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class MusicalProjectEvent : BaseEntity
{
    public Guid MusicalProjectId { get; set; }
    public MusicalProject MusicalProject { get; set; }
    public Guid EventId { get; set; }
    public Event Event { get; set; }
}
