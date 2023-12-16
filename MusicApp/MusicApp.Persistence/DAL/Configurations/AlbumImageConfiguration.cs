using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class AlbumImageConfiguration : IEntityTypeConfiguration<AlbumImage>
{
    public void Configure(EntityTypeBuilder<AlbumImage> builder)
    {
        builder.Property(ai => ai.Id)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("NEWID()");

        builder.Property(ai => ai.ImageUrl)
               .IsRequired()
               .HasMaxLength(1024);

        builder.Property(ai => ai.IsMainCover)
               .IsRequired();

    }
}
