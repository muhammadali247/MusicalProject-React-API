using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.TicketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.TicketFeatures.Queries.TicketGetAllQry;

public class TicketGetAllQueryHandler : IRequestHandler<TicketGetAllQuery, List<TicketViewDTO>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public TicketGetAllQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<List<TicketViewDTO>> Handle(TicketGetAllQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _ticketRepository.GetAllDetailedAsync();
        return _mapper.Map<List<TicketViewDTO>>(tickets);
    }
}
