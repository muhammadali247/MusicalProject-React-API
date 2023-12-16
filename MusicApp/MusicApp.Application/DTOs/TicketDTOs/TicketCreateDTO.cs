using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.TicketDTOs;

public class TicketCreateDTO
{
    public decimal Price { get; set; }
    public Guid EventId { get; set; }
    public TicketType Type { get; set; }
}
