using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(ev => ev.Id)
             .ValueGeneratedOnAdd()
             .HasDefaultValueSql("NEWID()");

        builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.CoverImageUrl)
            .HasMaxLength(200);

        builder.Property(e => e.LiveStreamUrl)
            .HasMaxLength(200);


        builder.Property(e => e.Location)
            .HasMaxLength(100);

        builder.HasMany(e => e.Tickets)   
                 .WithOne(t => t.Event)     
                 .HasForeignKey(t => t.EventId) 
                 .OnDelete(DeleteBehavior.Cascade);
    }

}
