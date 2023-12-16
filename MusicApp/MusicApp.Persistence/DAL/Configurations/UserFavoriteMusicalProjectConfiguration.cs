using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL.Configurations;

public class UserFavoriteMusicalProjectConfiguration : IEntityTypeConfiguration<UserFavoriteMusicalProject>
{
    public void Configure(EntityTypeBuilder<UserFavoriteMusicalProject> builder)
    {
        builder.Property(ufmp => ufmp.Id)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("NEWID()");

        builder.HasOne(ufmp => ufmp.UserProfile)
             .WithMany(up => up.UserFavoriteMusicalProjects)
             .HasForeignKey(ufmp => ufmp.UserProfileId);


        builder.HasOne(ufmp => ufmp.MusicalProject)
             .WithMany(a => a.UserFavoriteMusicalProjects)
             .HasForeignKey(ufmp => ufmp.MusicalProjectId);
    }
}
