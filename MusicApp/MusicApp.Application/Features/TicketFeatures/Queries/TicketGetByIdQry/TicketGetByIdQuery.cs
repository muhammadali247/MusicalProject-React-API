using MediatR;
using MusicApp.Application.DTOs.TicketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.TicketFeatures.Queries.TicketGetByIdQry;

public record TicketGetByIdQuery(Guid Id) : IRequest<TicketViewDTO>;

