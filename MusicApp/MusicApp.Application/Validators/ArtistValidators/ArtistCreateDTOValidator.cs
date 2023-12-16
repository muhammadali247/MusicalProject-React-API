using FluentValidation;
using MusicApp.Application.DTOs.ArtistDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.ArtistValidators;

public class ArtistCreateDTOValidator : AbstractValidator<ArtistCreateDTO>
{
    public ArtistCreateDTOValidator()
    {
        RuleFor(dto => dto.ArtistName)
            .NotEmpty().WithMessage("Artist name is required.")
            .MaximumLength(256).WithMessage("Artist name cannot exceed 256 characters.");

        RuleFor(dto => dto.ProjectIds)
            .NotEmpty().WithMessage("At least one project ID is required.");
    }
}
