using AutoMapper;
using FluentValidation;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.EventDTOs;
using MusicApp.Application.DTOs.TicketDTOs;
using MusicApp.Application.Features.TicketFeatures.Commands.TicketCreateCmd;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.EventFeatures.Commands.EventCreateCmd;

public class EventCreateCommandHandler : IRequestHandler<EventCreateCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<EventCreateDTO> _createValidator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;


    public EventCreateCommandHandler(IEventRepository eventRepository, IMapper mapper, IValidator<EventCreateDTO> createValidator, IUnitOfWork unitOfWork, IMediator mediator)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _createValidator = createValidator;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }


    public async Task<Guid> Handle(EventCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request.EventCreateDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        var newEvent = _mapper.Map<Event>(request.EventCreateDTO);
        newEvent = await _eventRepository.CreateAsync(newEvent);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Generate tickets if needed
        if (request.EventCreateDTO.GenerateTickets)
        {
            await GenerateTicketsForEvent(newEvent, request.EventCreateDTO, cancellationToken);
        }

        return newEvent.Id;
    }

    private async Task GenerateTicketsForEvent(Event newEvent, EventCreateDTO eventCreateDTO, CancellationToken cancellationToken)
    {
        for (int i = 0; i < eventCreateDTO.NumberOfTickets; i++)
        {
            var ticketCreateDto = new TicketCreateDTO
            {
                Price = eventCreateDTO.TicketPrice ?? 0,
                EventId = newEvent.Id,
                Type = eventCreateDTO.TicketType ?? TicketType.Regular
            };

            var ticketCommand = new TicketCreateCommand(ticketCreateDto);
            await _mediator.Send(ticketCommand, cancellationToken);
        }
    }
}
