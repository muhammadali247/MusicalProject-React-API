using MusicApp.Domain.Common;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Ticket : BaseEntity
{
    public decimal Price { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public Guid EventId { get; set; }
    public TicketType Type { get; set; }
    public TicketStatus Status { get; set; }
    public string? AccessToken { get; set; }

    public string? UserId { get; set; }
    public AppUser User { get; set; }
    public OrderItem? OrderItem { get; set; }
    public Event Event { get; set; }
}
