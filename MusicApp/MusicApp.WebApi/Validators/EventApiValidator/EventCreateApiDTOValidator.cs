using FluentValidation;
using MusicApp.WebApi.DTOs.EventApiDTOs;

namespace MusicApp.WebApi.Validators.EventApiValidator;

public class EventCreateApiDTOValidator : AbstractValidator<EventCreateApiDTO>
{
    public EventCreateApiDTOValidator()
    {
        // Validate Title
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(1, 100).WithMessage("Title must be between 1 and 100 characters.");

        // Validate Description
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(1, 500).WithMessage("Description must be between 1 and 500 characters.");

        // Validate EventDate
        RuleFor(x => x.EventDate)
            .GreaterThan(DateTime.Now).WithMessage("Event Date must be in the future.")
            .When(x => x.EventDate.HasValue);


        // Validate EventDuration
        RuleFor(x => x.EventDuration)
            .InclusiveBetween(1, 86400).WithMessage("Event Duration must be between 1 and 86400 seconds.")
            .When(x => x.EventDuration.HasValue);

        RuleFor(x => x.CoverImageFile)
                .Must(BeAValidImage).WithMessage("Invalid image format. Only JPEG, JPG, PNG, GIF are allowed.");

        // Validate LiveStreamUrl
        RuleFor(x => x.LiveStreamUrl)
            .Matches(@"^(http|https)://").When(x => !string.IsNullOrEmpty(x.LiveStreamUrl)).WithMessage("Live Stream URL must be a valid URL.");

        // Validate Location
        RuleFor(x => x.Location)
            .Length(0, 200).When(x => !string.IsNullOrEmpty(x.Location)).WithMessage("Location must be between 0 and 200 characters.");

        // Validate Status
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid Event Status.");

        // Validate MusicalProjectIds
        RuleFor(x => x.MusicalProjectIds)
            .Must(ids => ids == null || ids.All(id => id != Guid.Empty)).WithMessage("Invalid Musical Project IDs.");
    }
    private bool BeAValidImage(IFormFile file)
    {
        if (file == null) return false;

        string[] validImageTypes = { "image/jpeg", "image/png", "image/jpg", "image/gif" };
        return validImageTypes.Contains(file.ContentType);
    }
}
