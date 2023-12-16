using MusicApp.Application.Abstractions.Services;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Implementations.Services;

public class OTPService : IOTPService
{
    public string GenerateOTP()
    {
        Random random = new Random();
        int otpNumber = random.Next(100000, 1000000);
        return otpNumber.ToString();
    }

    public void SetOTPForUser(AppUser user)
    {
        user.OTP = GenerateOTP();
        user.OTPExpiryDate = DateTime.UtcNow.AddMinutes(5);  // OTP expires in 5 minutes
    }

}
