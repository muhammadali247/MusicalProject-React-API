using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Merchandise : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }
    public MerchandiseCategory Category { get; set; }

    public List<MerchandiseImage> MerchandiseImages { get; set; } = new List<MerchandiseImage>();
    public Guid? MainImageId { get; set; }
    public MerchandiseImage MainImage { get; set; }

    public Guid OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }
}
