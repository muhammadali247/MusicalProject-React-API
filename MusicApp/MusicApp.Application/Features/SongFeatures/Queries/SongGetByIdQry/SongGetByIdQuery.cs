using MediatR;
using MusicApp.Application.DTOs.SongDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.SongFeatures.Queries.SongGetByIdQry;

public record SongGetByIdQuery(Guid Id) : IRequest<SongViewDTO>;

