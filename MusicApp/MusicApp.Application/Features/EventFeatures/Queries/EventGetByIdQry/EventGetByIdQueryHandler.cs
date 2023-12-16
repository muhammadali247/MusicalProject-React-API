using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.EventDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.EventFeatures.Queries.EventGetByIdQry;

public class EventGetByIdQueryHandler : IRequestHandler<EventGetByIdQuery, EventViewDTO>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventGetByIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventViewDTO> Handle(EventGetByIdQuery request, CancellationToken cancellationToken)
    {
        var returnedEvent = await _eventRepository.GetByIdDetailedAsync(request.Id);

        if (returnedEvent == null) throw new NotFoundException(nameof(Event), request.Id);
        return _mapper.Map<EventViewDTO>(returnedEvent);
    }
}
