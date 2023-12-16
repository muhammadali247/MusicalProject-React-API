using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class MusicalProjectEventConfiguration : IEntityTypeConfiguration<MusicalProjectEvent>
{
    public void Configure(EntityTypeBuilder<MusicalProjectEvent> builder)
    {
        builder.Property(mpe => mpe.Id)
             .ValueGeneratedOnAdd()
             .HasDefaultValueSql("NEWID()");

        builder.HasOne(mpe => mpe.MusicalProject)
               .WithMany(mp => mp.MusicalProjectEvents)
               .HasForeignKey(mpe => mpe.MusicalProjectId);

        builder.HasOne(mpe => mpe.Event)
               .WithMany(e => e.MusicalProjectEvents)
               .HasForeignKey(mpe => mpe.EventId);
    }
}
