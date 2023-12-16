using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.EventDTOs;

public class EventCreateDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? EventDate { get; set; }
    public int? EventDuration { get; set; }
    public string CoverImageUrl { get; set; }
    public string? LiveStreamUrl { get; set; }
    public EventStatus? Status { get; set; }
    public string? Location { get; set; }
    public List<Guid>? MusicalProjectIds { get; set; }
    public bool GenerateTickets { get; set; }
    public int? NumberOfTickets { get; set; }
    public decimal? TicketPrice { get; set; }
    public TicketType? TicketType { get; set; }
}


