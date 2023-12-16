﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicApp.Persistence.DAL;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230809101250_madeSocialMediaPlatformEnum")]
    partial class madeSocialMediaPlatformEnum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicApp.Domain.Entities.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MainCoverAlbumImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MusicalProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("MainCoverAlbumImageId")
                        .IsUnique()
                        .HasFilter("[MainCoverAlbumImageId] IS NOT NULL");

                    b.HasIndex("MusicalProjectId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.AlbumGenre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GenreId");

                    b.ToTable("AlbumGenres");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.AlbumImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMainCover")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("AlbumImage");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.ArtistMusicalProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MusicalProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("MusicalProjectId");

                    b.ToTable("ArtistMusicalProjects");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.ArtistProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId")
                        .IsUnique();

                    b.HasIndex("UserProfileId")
                        .IsUnique();

                    b.ToTable("ArtistProfiles");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("ParentGenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ParentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentGenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Lyrics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SongId")
                        .IsUnique();

                    b.ToTable("Lyrics");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.MusicalProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCanceled")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFounded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MusicalProjects");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.MusicalProjectGenre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MusicalProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MusicalProjectId");

                    b.ToTable("MusicalProjectGenres");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.SocialMediaLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntityType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MusicalProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Platform")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<Guid?>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("MusicalProjectId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("SocialMediaLinks");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationInSeconds")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.UserFavoriteArtist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("UserFavoriteArtist");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.UserFavoriteGenre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("UserFavoriteGenre");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.UserFavoriteMusicalProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MusicalProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MusicalProjectId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("UserFavoriteMusicalProject");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Album", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.AlbumImage", "MainCoverAlbumImage")
                        .WithOne()
                        .HasForeignKey("MusicApp.Domain.Entities.Album", "MainCoverAlbumImageId");

                    b.HasOne("MusicApp.Domain.Entities.MusicalProject", "MusicalProject")
                        .WithMany("Albums")
                        .HasForeignKey("MusicalProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCoverAlbumImage");

                    b.Navigation("MusicalProject");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.AlbumGenre", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Album", "Album")
                        .WithMany("AlbumGenres")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Domain.Entities.Genre", "Genre")
                        .WithMany("AlbumGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.AlbumImage", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Album", "Album")
                        .WithMany("AlbumImages")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.ArtistMusicalProject", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Artist", "Artist")
                        .WithMany("ArtistMusicalProjects")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Domain.Entities.MusicalProject", "MusicalProject")
                        .WithMany("ArtistMusicalProjects")
                        .HasForeignKey("MusicalProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("MusicalProject");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.ArtistProfile", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Artist", "Artist")
                        .WithOne("Profile")
                        .HasForeignKey("MusicApp.Domain.Entities.ArtistProfile", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Domain.Entities.UserProfile", "UserProfile")
                        .WithOne("ArtistProfile")
                        .HasForeignKey("MusicApp.Domain.Entities.ArtistProfile", "UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Genre", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Genre", "ParentGenre")
                        .WithMany("SubGenres")
                        .HasForeignKey("ParentGenreId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentGenre");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Lyrics", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Song", "Song")
                        .WithOne("Lyrics")
                        .HasForeignKey("MusicApp.Domain.Entities.Lyrics", "SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.MusicalProjectGenre", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Genre", "Genre")
                        .WithMany("MusicalProjectGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Domain.Entities.MusicalProject", "MusicalProject")
                        .WithMany("MusicalProjectGenres")
                        .HasForeignKey("MusicalProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("MusicalProject");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.SocialMediaLink", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("MusicApp.Domain.Entities.MusicalProject", "MusicalProject")
                        .WithMany("SocialMediaLinks")
                        .HasForeignKey("MusicalProjectId");

                    b.HasOne("MusicApp.Domain.Entities.UserProfile", "UserProfile")
                        .WithMany("SocialMediaLinks")
                        .HasForeignKey("UserProfileId");

                    b.Navigation("Artist");

                    b.Navigation("MusicalProject");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Song", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.UserFavoriteArtist", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Domain.Entities.UserProfile", "UserProfile")
                        .WithMany("FavoriteArtists")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.UserFavoriteGenre", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Domain.Entities.UserProfile", "UserProfile")
                        .WithMany("FavoriteGenres")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.UserFavoriteMusicalProject", b =>
                {
                    b.HasOne("MusicApp.Domain.Entities.MusicalProject", "MusicalProject")
                        .WithMany()
                        .HasForeignKey("MusicalProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApp.Domain.Entities.UserProfile", "UserProfile")
                        .WithMany("FavoriteMusicalProjects")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicalProject");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Album", b =>
                {
                    b.Navigation("AlbumGenres");

                    b.Navigation("AlbumImages");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Artist", b =>
                {
                    b.Navigation("ArtistMusicalProjects");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Genre", b =>
                {
                    b.Navigation("AlbumGenres");

                    b.Navigation("MusicalProjectGenres");

                    b.Navigation("SubGenres");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.MusicalProject", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("ArtistMusicalProjects");

                    b.Navigation("MusicalProjectGenres");

                    b.Navigation("SocialMediaLinks");
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.Song", b =>
                {
                    b.Navigation("Lyrics")
                        .IsRequired();
                });

            modelBuilder.Entity("MusicApp.Domain.Entities.UserProfile", b =>
                {
                    b.Navigation("ArtistProfile");

                    b.Navigation("FavoriteArtists");

                    b.Navigation("FavoriteGenres");

                    b.Navigation("FavoriteMusicalProjects");

                    b.Navigation("SocialMediaLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
