using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Helpers.Enums;

public enum TicketStatus
{
    Available = 1, // The ticket is active and available for purchase.
    Sold, // The ticket is active and has been sold to a user.
    Used, // The ticket has been used to access the event -> inActive.
    Expired, // The ticket has expired and cannot be used. -> inActive.
    Cancelled // The ticket has been cancelled and is neither available nor valid -> inActive.
}
