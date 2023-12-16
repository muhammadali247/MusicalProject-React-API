using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Services;

public interface IOTPService
{
    public string GenerateOTP();
    void SetOTPForUser(AppUser user);

}
