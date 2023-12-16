using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class MusicalProjectConfiguration : IEntityTypeConfiguration<MusicalProject>
{
    public void Configure(EntityTypeBuilder<MusicalProject> builder)
    {
        builder.Property(mp => mp.Id)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("NEWID()");

        builder.Property(mp => mp.Name)
               .IsRequired()
                .HasMaxLength(256);

        builder.Property(mp => mp.Description)
          .IsRequired()
          .HasMaxLength(1024);

        builder.Property(mp => mp.DateFounded)
               .IsRequired(false);

        builder.Property(mp => mp.DateCanceled)
          .IsRequired(false);

        builder.Property(mp => mp.Type)
                  .IsRequired(false);
    }
}
