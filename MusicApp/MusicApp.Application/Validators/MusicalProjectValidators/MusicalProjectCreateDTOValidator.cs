using FluentValidation;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.MusicalProjectValidators;

public class MusicalProjectCreateDTOValidator : AbstractValidator<MusicalProjectCreateDTO>
{
    public MusicalProjectCreateDTOValidator()
    {
        RuleFor(dto => dto.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(256).WithMessage("Name cannot exceed 256 characters.");

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(1024).WithMessage("Description cannot exceed 1024 characters.");

        RuleFor(dto => dto.DateFounded)
            .NotNull().WithMessage("DateFounded is required.");


        RuleFor(dto => dto.DateCanceled)
            .GreaterThan(dto => dto.DateFounded).When(dto => dto.DateCanceled.HasValue).WithMessage("DateCanceled must be later than DateFounded.");

        RuleForEach(dto => dto.ArtistIds)
            .NotEmpty().WithMessage("At least one artist ID is required.");

        RuleForEach(dto => dto.GenreIds)
            .NotEmpty().WithMessage("At least one genre ID is required.");

        RuleFor(dto => dto.Type)
            .IsInEnum().WithMessage("Invalid project type.");

        RuleForEach(dto => dto.SocialMediaLinks)
          .SetValidator(new SocialMediaLinkDTOValidator());

    }
    private class SocialMediaLinkDTOValidator : AbstractValidator<MP_SocialMediaLinkDTO>
    {
        public SocialMediaLinkDTOValidator()
        {
            RuleFor(dto => dto.Platform)
                .IsInEnum().WithMessage("Invalid social media platform.");

            RuleFor(dto => dto.Url)
                .NotEmpty().WithMessage("Social media URL is required.")
                .MaximumLength(1024).WithMessage("Social media URL cannot exceed 1024 characters.");
        }
    }


}
