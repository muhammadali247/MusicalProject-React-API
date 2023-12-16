using FluentValidation;
using MusicApp.Application.DTOs.AlbumDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.AlbumValidators;

public class AlbumCreateDTOValidator : AbstractValidator<AlbumCreateDTO>
{
    public AlbumCreateDTOValidator()
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
            .SetValidator(new AlbumImageToAddDTOValidator());

        RuleFor(x => x.AlbumImages)
           .Must(HaveOnlyOneMainCover)
           .WithMessage("Only one image can be set as the main cover.");

        RuleForEach(x => x.Songs)
            .SetValidator(new SongToAddDTOValidator());
    }
    private bool HaveOnlyOneMainCover(IEnumerable<AlbumImageToAddDTO> albumImages)
    {
        return albumImages.Count(img => img.IsMainCover) <= 1;
    }

    private class AlbumImageToAddDTOValidator : AbstractValidator<AlbumImageToAddDTO>
    {
        public AlbumImageToAddDTOValidator()
        {
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Image URL is required.")
                .MaximumLength(255).WithMessage("Image URL cannot be longer than 255 characters.");

            RuleFor(x => x.IsMainCover)
                .NotNull().WithMessage("IsMainCover flag is required.");
        }
    }

    private class SongToAddDTOValidator : AbstractValidator<SongToAddDTO>
    {
        public SongToAddDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Song title is required.")
                .MaximumLength(512).WithMessage("Song title cannot be longer than 512 characters.");

            RuleFor(x => x.DurationInSeconds)
                .GreaterThan(0).WithMessage("Song duration must be greater than 0 seconds.");
        }
    }
}


