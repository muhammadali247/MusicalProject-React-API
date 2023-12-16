using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        // Primary Key configuration
        builder.Property(s => s.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        // Property configurations
        builder.Property(s => s.Title)
               .IsRequired()
               .HasMaxLength(512);

        builder.Property(s => s.DurationInSeconds)
               .IsRequired();

        // Relationships
        builder.HasOne(s => s.Album)
               .WithMany(a => a.Songs)
               .HasForeignKey(s => s.AlbumId)
               .OnDelete(DeleteBehavior.SetNull);

       
    }
}
