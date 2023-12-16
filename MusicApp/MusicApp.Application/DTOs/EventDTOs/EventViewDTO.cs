using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.EventDTOs;

public class EventViewDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime? EventDate { get; set; }
    public string CoverImageUrl { get; set; }
    public EventStatus? Status { get; set; }
    public string Location { get; set; }
    public int NumberOfTickets { get; set; }
    public List<string> MusicalProjectNames { get; set; } = new List<string>();
}
