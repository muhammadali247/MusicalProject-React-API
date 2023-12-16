using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class MusicalProjectGenreConfiguration : IEntityTypeConfiguration<MusicalProjectGenre>
{
    public void Configure(EntityTypeBuilder<MusicalProjectGenre> builder)
    {
        builder.Property(mpg => mpg.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        builder.HasOne(mpg => mpg.MusicalProject)
             .WithMany(mp => mp.MusicalProjectGenres)
             .HasForeignKey(mpg => mpg.MusicalProjectId);

        builder.HasOne(mpg => mpg.Genre)
               .WithMany(g => g.MusicalProjectGenres)
               .HasForeignKey(mpg => mpg.GenreId);
    }
}
