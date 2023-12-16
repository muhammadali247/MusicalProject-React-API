using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.EventDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.EventFeatures.Queries.EventGetAllQry;

public class EventGetAllQueryHandler : IRequestHandler<EventGetAllQuery, List<EventViewDTO>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventGetAllQueryHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }


    public async Task<List<EventViewDTO>> Handle(EventGetAllQuery request, CancellationToken cancellationToken)
    {
        var events = await _eventRepository.GetAllDetailedAsync();
        return _mapper.Map<List<EventViewDTO>>(events);
    }
}
