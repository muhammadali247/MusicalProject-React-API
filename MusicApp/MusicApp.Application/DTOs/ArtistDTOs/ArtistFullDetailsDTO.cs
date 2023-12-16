using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.ArtistDTOs;

public class ArtistFullDetailsDTO
{
    public Guid Id { get; set; }
    public string ArtistName { get; set; }
    public List<ArtistAssociatedProjectDTO> AssociatedProjects { get; set; } = new List<ArtistAssociatedProjectDTO>();
}

public class ArtistAssociatedProjectDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
