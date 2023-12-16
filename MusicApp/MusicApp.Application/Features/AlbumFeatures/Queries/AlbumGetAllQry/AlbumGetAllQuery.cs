using MediatR;
using MusicApp.Application.DTOs.AlbumDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AlbumFeatures.Queries.AlbumGetAllQry;

public record AlbumGetAllQuery : IRequest<List<AlbumViewDTO>>;

