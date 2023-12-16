using FluentValidation;
using MusicApp.Application.DTOs.TicketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.TicketValidators;

public class TicketCreateDTOValidator : AbstractValidator<TicketCreateDTO>
{
    public TicketCreateDTOValidator()
    {
        RuleFor(dto => dto.Price)
               .GreaterThan(0)
               .WithMessage("Price must be greater than 0.");

        RuleFor(dto => dto.EventId)
            .NotEmpty()
            .WithMessage("EventId is required.");

        RuleFor(dto => dto.Type)
            .IsInEnum()
            .WithMessage("Invalid TicketType.");
    }
}
