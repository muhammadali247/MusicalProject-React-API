using MediatR;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.MusicalProjectFeatures.Queries.MusicalProjectGetAllQry;

public record MusicalProjectGetAllQuery : IRequest<List<MusicalProjectViewDTO>>;
