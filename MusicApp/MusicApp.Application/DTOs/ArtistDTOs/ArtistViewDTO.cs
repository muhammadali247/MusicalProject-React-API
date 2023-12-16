using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.ArtistDTOs;

public class ArtistViewDTO
{
    public Guid Id { get; set; }
    public string ArtistName { get; set; }
    public List<string> ProjectNames { get; set; } = new List<string>();    
}


