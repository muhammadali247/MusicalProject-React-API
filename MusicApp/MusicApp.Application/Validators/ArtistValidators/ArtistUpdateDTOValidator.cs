using FluentValidation;
using MusicApp.Application.DTOs.ArtistDTOs;

namespace MusicApp.Application.Validations.ArtistValidations;

public class ArtistUpdateDTOValidator : AbstractValidator<ArtistUpdateDTO>
{
    public ArtistUpdateDTOValidator()
    {
        RuleFor(dto => dto.ArtistName)
            .NotEmpty().WithMessage("Artist name is required.")
            .MaximumLength(256).WithMessage("Artist name cannot exceed 256 characters.");

        // Optional validation for ProjectIdsToAdd and ProjectIdsToRemove
        When(dto => dto.ProjectIdsToAdd != null && dto.ProjectIdsToAdd.Any(), () =>
        {
            RuleFor(dto => dto.ProjectIdsToAdd)
                .Must(ids => ids.All(id => id != Guid.Empty)).WithMessage("Invalid project ID.");

            RuleFor(dto => dto.ProjectIdsToAdd)
                .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("Duplicate project IDs are not allowed.");
        });

        When(dto => dto.ProjectIdsToRemove != null && dto.ProjectIdsToRemove.Any(), () =>
        {
            RuleFor(dto => dto.ProjectIdsToRemove)
                .Must(ids => ids.All(id => id != Guid.Empty)).WithMessage("Invalid project ID.");

            RuleFor(dto => dto.ProjectIdsToRemove)
                .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("Duplicate project IDs are not allowed.");
        });
    }
}
