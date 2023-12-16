using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.ArtistDTOs;

public class ArtistUpdateDTO
{
    public string? ArtistName { get; set; }
    public List<Guid>? ProjectIdsToAdd { get; set; }
    public List<Guid>? ProjectIdsToRemove { get; set; }
}
