using FluentValidation;
using MusicApp.WebApi.DTOs.AlbumApiDTOs;

namespace MusicApp.WebApi.Validators.AlbumApiValidator;

public class AlbumCreateApiDTOValidator : AbstractValidator<AlbumCreateApiDTO>
{
    public AlbumCreateApiDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(512).WithMessage("Title cannot be longer than 512 characters.");

        RuleFor(x => x.ReleaseYear)
            .NotEmpty().WithMessage("Release year is required.")
            .InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Release year must be between 1900 and {DateTime.Now.Year}.");

        RuleFor(x => x.MusicalProjectId)
            .NotEmpty().WithMessage("Musical Project ID is required.");

        RuleForEach(x => x.AlbumImages)
            .SetValidator(new AlbumImageToAddApiDTOValidator());

        RuleFor(x => x.AlbumImages)
           .Must(HaveOnlyOneMainCover)
           .WithMessage("Only one image can be set as the main cover.");

        RuleForEach(x => x.Songs)
            .SetValidator(new SongToAddApiDTOValidator());
    }

    private bool HaveOnlyOneMainCover(System.Collections.Generic.IEnumerable<AlbumImageToAddApiDTO> albumImages)
    {
        return albumImages.Count(img => img.IsMainCover) <= 1;
    }

    private class AlbumImageToAddApiDTOValidator : AbstractValidator<AlbumImageToAddApiDTO>
    {
        public AlbumImageToAddApiDTOValidator()
        {
            RuleFor(x => x.ImageFile)
                .NotNull().WithMessage("Image is required.")
                .Must(BeAValidImage).WithMessage("Invalid image format. Only JPEG, JPG, PNG, GIF are allowed.");

            RuleFor(x => x.IsMainCover)
                .NotNull().WithMessage("IsMainCover flag is required.");
        }

        private bool BeAValidImage(IFormFile file)
        {
            if (file == null) return false;

            string[] validImageTypes = { "image/jpeg", "image/png", "image/jpg", "image/gif" };
            return validImageTypes.Contains(file.ContentType);
        }
    }

    private class SongToAddApiDTOValidator : AbstractValidator<SongToAddApiDTO>
    {
        public SongToAddApiDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Song title is required.")
                .MaximumLength(512).WithMessage("Song title cannot be longer than 512 characters.");

            RuleFor(x => x.DurationInSeconds)
                .GreaterThan(0).WithMessage("Song duration must be greater than 0 seconds.");
        }
    }
}


