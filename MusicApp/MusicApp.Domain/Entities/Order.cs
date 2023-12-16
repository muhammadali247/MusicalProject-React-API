using MusicApp.Domain.Common;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Order : BaseEntity
{
    public AppUser User { get; set; }
    public string UserId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public decimal TotalPrice { get; set; }  // Calculated from the individual OrderItems
    public OrderStatus Status { get; set; } 

    public Payment Payment { get; set; }
}
