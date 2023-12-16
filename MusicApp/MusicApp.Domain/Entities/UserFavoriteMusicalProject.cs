using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class UserFavoriteMusicalProject : BaseEntity
{
    public Guid UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }

    public Guid MusicalProjectId { get; set; }
    public MusicalProject MusicalProject { get; set; }
}
