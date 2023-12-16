using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Helpers.Enums;

public enum EventStatus
{
    Draft = 1, //The event has been created but not yet made public or finalized.
    Scheduled, //The event has been planned and is set to take place at the future date specified in EventDate.
    Confirmed, // The event is confirmed to proceed, either by an admin or other metrics.
    Ongoing, //The event is currently happening.
    Completed, //The event has ended.
    Cancelled, //The event has been cancelled and will not take place
    Postponed, //The event has been delayed to a future date, but it's not yet known when it will occur
    Rescheduled, //The event has been postponed, but a new date has been set
    SoldOut, //All tickets for the event have been sold.
    Archived //The event is over and has been archived for historical purposes.
}
