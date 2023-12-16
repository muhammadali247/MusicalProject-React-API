using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.AccountDTOs;

public class LoginDTO
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
