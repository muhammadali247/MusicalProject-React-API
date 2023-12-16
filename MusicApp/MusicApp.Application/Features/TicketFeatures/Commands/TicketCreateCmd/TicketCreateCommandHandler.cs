using AutoMapper;
using FluentValidation;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.EventDTOs;
using MusicApp.Application.DTOs.TicketDTOs;
using MusicApp.Application.Features.EventFeatures.Queries.EventGetByIdQry;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.TicketFeatures.Commands.TicketCreateCmd;

public class TicketCreateCommandHandler : IRequestHandler<TicketCreateCommand, Guid>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<TicketCreateDTO> _createValidator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;


    public TicketCreateCommandHandler(ITicketRepository ticketRepository, IMapper mapper, IValidator<TicketCreateDTO> createValidator, IUnitOfWork unitOfWork, IMediator mediator)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
        _createValidator = createValidator;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }


    public async Task<Guid> Handle(TicketCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request.TicketCreateDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        var newTicket = _mapper.Map<Ticket>(request.TicketCreateDTO);
        newTicket = await _ticketRepository.CreateAsync(newTicket);

        // Fetch the event information using MediatR query
        var eventQuery = new EventGetByIdQuery(request.TicketCreateDTO.EventId);
        var eventEntity = await _mediator.Send(eventQuery, cancellationToken);

        newTicket.ExpirationDate = CalculateExpirationDate(eventEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return newTicket.Id;
    }

    private DateTime CalculateExpirationDate(EventViewDTO eventEntity)
    {
        // Calculate the expiration date based on the event's date
        return eventEntity.EventDate.Value.AddHours(-1);
    }
}
