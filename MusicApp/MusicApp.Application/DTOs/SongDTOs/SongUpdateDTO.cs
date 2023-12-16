using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.SongDTOs;

public class SongUpdateDTO
{
    public string Title { get; set; }
    public int DurationInSeconds { get; set; }
    public Guid AlbumId { get; set; }
}
