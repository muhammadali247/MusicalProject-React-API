using FluentValidation;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Validators.MusicalProjectValidators;

public class MusicalProjectUpdateDTOValidator : AbstractValidator<MusicalProjectUpdateDTO>
{
    public MusicalProjectUpdateDTOValidator()
    {
        RuleFor(dto => dto.Name)
              .MaximumLength(256).WithMessage("Name cannot exceed 256 characters.");

        RuleFor(dto => dto.Description)
            .MaximumLength(1024).WithMessage("Description cannot exceed 1024 characters.");

        When(mp => mp.DateFounded.HasValue && mp.DateCanceled.HasValue, () =>
        {
            RuleFor(mp => mp.DateCanceled).GreaterThan(mp => mp.DateFounded.Value).WithMessage("'DateCanceled' must be after 'DateFounded'.");
        });

        RuleFor(dto => dto.Type)
            .IsInEnum().When(dto => dto.Type.HasValue).WithMessage("Invalid project type.");

        When(dto => dto.ArtistIdsToAdd != null && dto.ArtistIdsToAdd.Any(), () =>
        {
            RuleFor(dto => dto.ArtistIdsToAdd)
                .Must(ids => ids.All(id => id != Guid.Empty)).WithMessage("Invalid artist ID.")
                .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("Duplicate artist IDs are not allowed.");
        });

        When(dto => dto.ArtistIdsToRemove != null && dto.ArtistIdsToRemove.Any(), () =>
        {
            RuleFor(dto => dto.ArtistIdsToRemove)
                .Must(ids => ids.All(id => id != Guid.Empty)).WithMessage("Invalid artist ID.")
                .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("Duplicate artist IDs are not allowed.");
        });

        When(dto => dto.GenreIdsToAdd != null && dto.GenreIdsToAdd.Any(), () =>
        {
            RuleFor(dto => dto.GenreIdsToAdd)
                .Must(ids => ids.All(id => id != Guid.Empty)).WithMessage("Invalid genre ID.")
                .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("Duplicate genre IDs are not allowed.");
        });


        When(dto => dto.GenreIdsToRemove != null && dto.GenreIdsToRemove.Any(), () =>
        {
            RuleFor(dto => dto.GenreIdsToRemove)
                .Must(ids => ids.All(id => id != Guid.Empty)).WithMessage("Invalid genre ID.")
                .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("Duplicate genre IDs are not allowed.");
        });

        When(mp => mp.SocialMediaLinksToAdd != null && mp.SocialMediaLinksToAdd.Any(), () =>
        {
            RuleForEach(mp => mp.SocialMediaLinksToAdd).ChildRules(linkRules =>
            {
                linkRules.RuleFor(link => link.Platform)
                    .NotEmpty().WithMessage("Social media platform is required.")
                    .IsInEnum().WithMessage("Invalid social media platform.");

                linkRules.RuleFor(link => link.Url)
                    .NotEmpty().WithMessage("Social media URL is required.")
                    .MaximumLength(1024).WithMessage("Social media URL cannot exceed 1024 characters.");
            });
        });

        When(mp => mp.SocialMediaLinkIdsToRemove != null && mp.SocialMediaLinkIdsToRemove.Any(), () =>
        {
            RuleFor(mp => mp.SocialMediaLinkIdsToRemove)
                .Must(ids => ids.All(id => id != Guid.Empty)) 
                .WithMessage("Invalid social media link ID.");

            RuleFor(mp => mp.SocialMediaLinkIdsToRemove)
                .Must(ids => ids.Distinct().Count() == ids.Count)
                .WithMessage("Duplicate social media link IDs are not allowed.");
        });

        When(mp => mp.SocialMediaLinksToUpdate != null && mp.SocialMediaLinksToUpdate.Any(), () =>
        {
            // Ensure each link has a valid ID
            RuleForEach(mp => mp.SocialMediaLinksToUpdate)
                .ChildRules(link =>
                {
                    link.RuleFor(l => l.Id)
                        .NotEqual(Guid.Empty) // Assuming IDs are of type Guid. Adjust if they are another type.
                        .WithMessage("Invalid social media link ID.");

                    // Ensure `Platform` is populated
                    link.RuleFor(link => link.Platform)
                        .NotEmpty().WithMessage("Social media platform is required.")
                        .IsInEnum().WithMessage("Invalid social media platform.");

                    // Ensure `Url` is populated
                    link.RuleFor(l => l.Url)
                        .NotEmpty()
                        .WithMessage("Social media URL is required.")
                        .MaximumLength(1024)
                        .WithMessage("Social media URL cannot exceed 1024 characters.");
                });

            // Ensure there are no duplicate IDs in the list
            RuleFor(mp => mp.SocialMediaLinksToUpdate)
                .Must(links => links.GroupBy(l => l.Id).All(g => g.Count() == 1))
                .WithMessage("Duplicate social media link IDs are not allowed.");
        });


    }

}