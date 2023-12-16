using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.Common;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Helpers.Enums;
using System.Threading;
using MusicApp.Persistence.DAL.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.DAL;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<MusicalProject> MusicalProjects { get; set; }
    public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<AlbumGenre> AlbumGenres { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<AlbumImage> AlbumImages { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserFavoriteGenre> UserFavoriteGenres { get; set; }
    public DbSet<UserFavoriteArtist> UserFavoriteArtists { get; set; }
    public DbSet<UserFavoriteMusicalProject> UserFavoriteMusicalProjects { get; set; }
    public DbSet<ArtistProfile> ArtistProfiles { get; set; }
    public DbSet<ArtistMusicalProject> ArtistMusicalProjects { get; set; }
    public DbSet<MusicalProjectGenre> MusicalProjectGenres { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<MusicalProjectEvent> MusicalProjectEvents { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // or modelBuilder.ApplyConfigurationFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);

        // Seed Roles
        var roleIds = SeedRoles(modelBuilder);

        // Seed Users
        SeedUsers(modelBuilder, roleIds);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.ModifiedDate = DateTime.Now;

            if(entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    private Dictionary<RoleEnum, string> SeedRoles(ModelBuilder modelBuilder)
    {
        var roleIds = new Dictionary<RoleEnum, string>
            {
                {RoleEnum.Admin, "8f177b9b-2126-42b3-a9ea-113e526a763a"},
                {RoleEnum.SuperAdmin, "01fec4cb-7540-48c5-b08a-aa6642957f1c"},
                {RoleEnum.Member, "63ded149-0cc6-43cd-bfc4-635dc3de2a9b"}
            };

        foreach (var role in Enum.GetValues(typeof(RoleEnum)))
        {
            var roleName = role.ToString();
            var normalizedRoleName = roleName.ToUpperInvariant();
            var roleId = roleIds[(RoleEnum)role];  

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = roleId, Name = roleName, NormalizedName = normalizedRoleName });
        }

        return roleIds;
    }

    private void SeedUsers(ModelBuilder modelBuilder, Dictionary<RoleEnum, string> roleIds)
    {
        var adminUserId = "04da0a6b-6fd2-4779-843a-3e7c5892da1c";
        var adminUser = CreateAppUser(adminUserId, "Admin", "Admin", "admin", "admin@gmail.com", "Aa@12345", "+1357924680");

        var superAdminUserId = "a09c2ad5-7446-4435-91c9-cd038b96b3ac";
        var superAdminUser = CreateAppUser(superAdminUserId, "SuperAdmin", "SuperAdmin", "superadmin", "superadmin@gmail.com", "Ss@12345", "+0246813579");

        modelBuilder.Entity<AppUser>().HasData(adminUser);
        modelBuilder.Entity<AppUser>().HasData(superAdminUser);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = roleIds[RoleEnum.Admin], UserId = adminUser.Id },
            new IdentityUserRole<string> { RoleId = roleIds[RoleEnum.SuperAdmin], UserId = superAdminUser.Id }
        );
    }

    private AppUser CreateAppUser(string id, string firstname, string lastname, string userName, string email, string password, string phoneNumber)
    {
        var user = new AppUser
        {
            Id = id,
            Firstname = firstname,
            Lastname = lastname,    
            UserName = userName,
            NormalizedUserName = userName.ToUpperInvariant(),
            Email = email,
            NormalizedEmail = email.ToUpperInvariant(),
            EmailConfirmed = true,
            PhoneNumber = phoneNumber,
            PhoneNumberConfirmed = true,
        };

        var passwordHasher = new PasswordHasher<AppUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, password);

        return user;
    }
}
