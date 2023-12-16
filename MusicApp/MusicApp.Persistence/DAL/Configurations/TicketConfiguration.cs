using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.Id)
             .ValueGeneratedOnAdd()
             .HasDefaultValueSql("NEWID()");

        builder.Property(t => t.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(t => t.PurchaseDate)
            .HasColumnType("datetime");

        builder.Property(t => t.ExpirationDate)
            .HasColumnType("datetime");

        builder.Property(t => t.Type)
           .IsRequired();

        builder.Property(t => t.Status)
                  .IsRequired();
    }
}
