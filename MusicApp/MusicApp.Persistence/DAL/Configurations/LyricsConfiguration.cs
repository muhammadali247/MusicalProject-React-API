using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class LyricsConfiguration : IEntityTypeConfiguration<Lyrics>
{
    public void Configure(EntityTypeBuilder<Lyrics> builder)
    {
        // Primary Key configuration
        builder.Property(l => l.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        // Property configurations
        builder.Property(l => l.Content)
               .IsRequired();

        builder.Property(l => l.Author)
               .HasMaxLength(256);

        // Relationship configuration
        builder.HasOne(l => l.Song)
               .WithOne(s => s.Lyrics)
               .HasForeignKey<Lyrics>(l => l.SongId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
