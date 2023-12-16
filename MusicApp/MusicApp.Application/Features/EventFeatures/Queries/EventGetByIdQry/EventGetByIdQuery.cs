using MediatR;
using MusicApp.Application.DTOs.EventDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.EventFeatures.Queries.EventGetByIdQry;

public record EventGetByIdQuery(Guid Id) : IRequest<EventViewDTO>;

