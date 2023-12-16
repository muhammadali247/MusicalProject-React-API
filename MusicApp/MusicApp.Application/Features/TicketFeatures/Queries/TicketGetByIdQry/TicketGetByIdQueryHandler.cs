using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.TicketDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.TicketFeatures.Queries.TicketGetByIdQry;

public class TicketGetByIdQueryHandler : IRequestHandler<TicketGetByIdQuery, TicketViewDTO>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public TicketGetByIdQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<TicketViewDTO> Handle(TicketGetByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdDetailedAsync(request.Id);

        if (ticket == null) throw new NotFoundException(nameof(Ticket), request.Id);
        return _mapper.Map<TicketViewDTO>(ticket);
    }
}
