using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.DTOs.SongDTOs;

public class SongViewDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int DurationInSeconds { get; set; }
    public int? TrackOrderNumber { get; set; }

    public string AlbumTitle { get; set; }
    public string LyricsContent { get; set; }
}
