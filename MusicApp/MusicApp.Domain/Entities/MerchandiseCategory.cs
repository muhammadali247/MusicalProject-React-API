using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class MerchandiseCategory : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid? ParentId { get; set; }
    public MerchandiseCategory ParentCategory { get; set; }
    public List<MerchandiseCategory> SubCategories { get; set; } = new List<MerchandiseCategory>();

    public ICollection<Merchandise> Merchandises { get; set; }
}
