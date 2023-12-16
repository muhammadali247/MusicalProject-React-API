using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class MerchandiseImage : BaseEntity
{
    public string ImageUrl { get; set; }
    public bool IsMainImage { get; set; }

    public Guid MerchandiseId { get; set; }
    public Merchandise Merchandise { get; set; }
}
