using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.Entities;

public class AppUser : IdentityUser
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; } = true;
    public string? ConnectionId { get; set; }
    public string? OTP { get; set; }
    public DateTime? OTPExpiryDate { get; set; }
    public UserProfile? UserProfile { get; set; }
}