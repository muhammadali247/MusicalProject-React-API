using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.UserDTOs;

public class UserViewDTO
{
    public string Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public List<string> Roles { get; set; }
    public string ProfileImageUrl { get; set; }
}
