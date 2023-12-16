using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Helpers.Enums;

public enum OrderStatus
{
    Pending = 1,   // Order created but payment not yet processed
    Paid,          // Payment successfully processed
    Completed,     // Order has been fulfilled
    Cancelled,     // Order has been cancelled
}
