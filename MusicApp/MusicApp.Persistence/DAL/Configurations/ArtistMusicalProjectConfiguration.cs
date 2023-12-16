using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class ArtistMusicalProjectConfiguration : IEntityTypeConfiguration<ArtistMusicalProject>
{
    public void Configure(EntityTypeBuilder<ArtistMusicalProject> builder)
    {
        builder.Property(mp => mp.Id)
             .ValueGeneratedOnAdd()
             .HasDefaultValueSql("NEWID()");

        builder.HasOne(amp => amp.Artist)
            .WithMany(a => a.ArtistMusicalProjects)
            .HasForeignKey(amp => amp.ArtistId);

        builder.HasOne(amp => amp.MusicalProject)
            .WithMany(mp => mp.ArtistMusicalProjects)
            .HasForeignKey(amp => amp.MusicalProjectId);
    }
}