using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class UserFavoriteArtistConfiguration : IEntityTypeConfiguration<UserFavoriteArtist>
{
    public void Configure(EntityTypeBuilder<UserFavoriteArtist> builder)
    {
        builder.Property(ufa => ufa.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        builder.HasOne(ufa => ufa.UserProfile)
             .WithMany(up => up.UserFavoriteArtists)
             .HasForeignKey(ufa => ufa.UserProfileId);


        builder.HasOne(ufa => ufa.Artist)
             .WithMany(a => a.UserFavoriteArtists)
             .HasForeignKey(ufa => ufa.ArtistId);
    }
}
