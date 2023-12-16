using MusicApp.Domain.Common;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
    public PaymentMethod Method { get; set; } 
    public string TransactionId { get; set; }  // ID from the payment gateway

    //public AppUser User { get; set; }         // must be added and controller for cascade
    //public string UserId { get; set; }        // must be added and controller for cascade

    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}
