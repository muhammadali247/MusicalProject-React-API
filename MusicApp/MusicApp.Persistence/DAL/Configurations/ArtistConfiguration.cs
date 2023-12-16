using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.Property(a => a.Id)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("NEWID()");

        builder.Property(a => a.ArtistName)
           .IsRequired()
           .HasMaxLength(256);
    }
}