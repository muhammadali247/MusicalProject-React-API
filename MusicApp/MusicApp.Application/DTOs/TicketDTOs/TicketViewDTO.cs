using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.TicketDTOs;

public class TicketViewDTO
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public TicketType Type { get; set; }
    public TicketStatus Status { get; set; }
    public string EventTitle { get; set; } 
}
