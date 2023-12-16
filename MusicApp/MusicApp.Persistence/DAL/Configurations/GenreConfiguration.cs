using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(a => a.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        builder.Property(g => g.Name)
              .IsRequired()
              .HasMaxLength(128);

        builder.HasOne(g => g.ParentGenre)
              .WithMany(g => g.SubGenres)
              .HasForeignKey(g => g.ParentGenreId)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
