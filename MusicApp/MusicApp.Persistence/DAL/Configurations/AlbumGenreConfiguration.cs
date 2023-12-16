using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class AlbumGenreConfiguration : IEntityTypeConfiguration<AlbumGenre>
{
    public void Configure(EntityTypeBuilder<AlbumGenre> builder)
    {
        builder.Property(ag => ag.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        builder.HasOne(ag => ag.Album)
               .WithMany(a => a.AlbumGenres)
               .HasForeignKey(ag => ag.AlbumId);

        builder.HasOne(ag => ag.Genre)
               .WithMany(g => g.AlbumGenres)
               .HasForeignKey(ag => ag.GenreId);
    }
}
