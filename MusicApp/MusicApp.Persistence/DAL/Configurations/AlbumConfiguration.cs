using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.Property(a => a.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");

        builder.Property(a => a.Title)
               .IsRequired()
               .HasMaxLength(512);

        builder.Property(a => a.ReleaseYear)
                .IsRequired();

        builder.HasMany(a => a.AlbumImages) 
                   .WithOne(ai => ai.Album)    
                   .HasForeignKey(ai => ai.AlbumId)  
                   .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.MainCoverAlbumImage)
               .WithOne()
               .HasForeignKey<Album>(a => a.MainCoverAlbumImageId);
    }
}
