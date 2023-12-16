using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class SocialMediaLinkConfiguration : IEntityTypeConfiguration<SocialMediaLink>
{
    public void Configure(EntityTypeBuilder<SocialMediaLink> builder)
    {
        builder.Property(a => a.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        builder.Property(sml => sml.Platform)
              .IsRequired()
              .HasConversion<int>();

        builder.Property(sml => sml.Url)
               .IsRequired()
               .HasMaxLength(1024);

        builder.Property(sml => sml.ArtistId)
               .IsRequired(false);

        builder.Property(sml => sml.UserProfileId)
              .IsRequired(false);

        builder.Property(sml => sml.MusicalProjectId)
              .IsRequired(false);
    }
}
