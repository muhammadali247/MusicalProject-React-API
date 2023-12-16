using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class UserFavoriteGenreConfiguration : IEntityTypeConfiguration<UserFavoriteGenre>
{
    public void Configure(EntityTypeBuilder<UserFavoriteGenre> builder)
    {

        builder.Property(ufg => ufg.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        builder.HasOne(ufg => ufg.UserProfile)
             .WithMany(up => up.UserFavoriteGenres)
             .HasForeignKey(ufa => ufa.UserProfileId);


        builder.HasOne(ufa => ufa.Genre)
             .WithMany(a => a.UserFavoriteGenres)
             .HasForeignKey(ufa => ufa.GenreId);
    }
}
