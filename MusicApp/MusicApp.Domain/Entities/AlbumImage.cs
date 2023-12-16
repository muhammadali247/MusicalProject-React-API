using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class AlbumImage : BaseEntity
{
    public string ImageUrl { get; set; }

    public Guid AlbumId { get; set; }
    public Album Album { get; set; }
    public bool IsMainCover { get; set; }

}
