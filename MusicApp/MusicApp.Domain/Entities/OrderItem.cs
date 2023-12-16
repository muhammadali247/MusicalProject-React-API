using MusicApp.Domain.Common;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public OrderItemType OrderItemType { get; set; }
    public Guid ItemId { get; set; }  // Can point to either a Ticket or Merchandise
    public decimal Price { get; set; } // Price at the time of purchase
}
