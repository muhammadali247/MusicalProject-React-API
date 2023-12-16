using MusicApp.Domain.Helpers.Enums;

namespace MusicApp.WebApi.DTOs.EventApiDTOs;

public class EventCreateApiDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? EventDate { get; set; }
    public int? EventDuration { get; set; }
    public IFormFile CoverImageFile { get; set; }
    public string? LiveStreamUrl { get; set; }
    public string? Location { get; set; }
    public EventStatus? Status { get; set; }
    public List<Guid>? MusicalProjectIds { get; set; }
    public bool GenerateTickets { get; set; }
    public int? NumberOfTickets { get; set; }
    public decimal? TicketPrice { get; set; }
    public TicketType? TicketType { get; set; }
}
