using MediatR;
using MusicApp.Application.DTOs.ArtistDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.ArtistFeatures.Queries.ArtistGetAllQry;

public record ArtistGetAllQuery : IRequest<List<ArtistViewDTO>>;
