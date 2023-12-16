using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.ArtistDTOs;

public class ArtistCreateDTO
{
    public string ArtistName { get; set; }
    public List<Guid> ProjectIds { get; set; } = new List<Guid>();
}
