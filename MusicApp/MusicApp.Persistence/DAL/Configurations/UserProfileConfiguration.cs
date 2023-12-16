using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.Property(up => up.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        // Configure one-to-one relationship with AppUser
        builder.HasOne(up => up.User)
             .WithOne(au => au.UserProfile)
             .HasForeignKey<UserProfile>(up => up.UserId);

        builder.HasMany(up => up.SocialMediaLinks)
                    .WithOne(sml => sml.UserProfile)
                    .HasForeignKey(sml => sml.UserProfileId);
    }
}
