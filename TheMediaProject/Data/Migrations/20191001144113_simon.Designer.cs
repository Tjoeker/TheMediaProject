﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheMediaProject.Data;

namespace TheMediaProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191001144113_simon")]
    partial class simon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.CrewMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CrewMembers");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<byte[]>("Photo");

                    b.Property<TimeSpan>("PlayTime");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.MovieCrewMember", b =>
                {
                    b.Property<int>("CrewMemberId");

                    b.Property<int>("MovieId");

                    b.Property<int>("MemberRole");

                    b.HasKey("CrewMemberId", "MovieId");

                    b.ToTable("MovieCrewMember");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MovieGenres");

                    b.HasData(
                        new { Id = 1, Name = "Absurdist" },
                        new { Id = 2, Name = "Action" },
                        new { Id = 3, Name = "Adventure" },
                        new { Id = 4, Name = "Comedy" },
                        new { Id = 5, Name = "Crime" },
                        new { Id = 6, Name = "Drama" },
                        new { Id = 7, Name = "Fantasy" },
                        new { Id = 8, Name = "Historical" },
                        new { Id = 9, Name = "Historical Fiction" },
                        new { Id = 10, Name = "Horror" },
                        new { Id = 11, Name = "Mystery" },
                        new { Id = 12, Name = "Romance" },
                        new { Id = 13, Name = "Satire" },
                        new { Id = 14, Name = "Science Fiction" },
                        new { Id = 15, Name = "Thriller" },
                        new { Id = 16, Name = "Western" }
                    );
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.MovieGenreMovie", b =>
                {
                    b.Property<int>("MovieGenreId");

                    b.Property<int>("MovieId");

                    b.HasKey("MovieGenreId", "MovieId");

                    b.ToTable("MovieGenreMovies");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.Serie.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<TimeSpan>("PlayTime");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<int>("SeasonId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.Serie.MovieGenreSeries", b =>
                {
                    b.Property<int>("MovieGenreId");

                    b.Property<int>("SerieId");

                    b.HasKey("MovieGenreId", "SerieId");

                    b.ToTable("MovieGenreSeries");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.Serie.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SeasonNumber");

                    b.Property<int>("SeriesId");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.Serie.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.Serie.SeriesCrewMember", b =>
                {
                    b.Property<int>("CrewMemberId");

                    b.Property<int>("MovieId");

                    b.Property<int>("MemberRole");

                    b.HasKey("CrewMemberId", "MovieId");

                    b.ToTable("SeriesCrewMembers");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Music.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumArtistId");

                    b.Property<int>("GenreId");

                    b.Property<byte[]>("Photo");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AlbumArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Music.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("SongId");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Music.MusicGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MusicGenres");

                    b.HasData(
                        new { Id = 1, Name = "Industrial" },
                        new { Id = 2, Name = "Metal" },
                        new { Id = 3, Name = "Hardcore Punk" },
                        new { Id = 4, Name = "Rock 'n' Roll" },
                        new { Id = 5, Name = "Classic Rock" },
                        new { Id = 6, Name = "Punk Rock" },
                        new { Id = 7, Name = "New Wave" },
                        new { Id = 8, Name = "Alternative Rock" },
                        new { Id = 9, Name = "Contemporary Rock" },
                        new { Id = 10, Name = "Pop" },
                        new { Id = 11, Name = "Country" },
                        new { Id = 12, Name = "Rhythm 'n' Blues" },
                        new { Id = 13, Name = "Blues" },
                        new { Id = 14, Name = "Gospel" },
                        new { Id = 15, Name = "Jazz" },
                        new { Id = 16, Name = "Reggae" },
                        new { Id = 17, Name = "Rap" },
                        new { Id = 18, Name = "Breakbeat" },
                        new { Id = 19, Name = "Drum 'n' Bass" },
                        new { Id = 20, Name = "Hardcore" },
                        new { Id = 21, Name = "Techno" },
                        new { Id = 22, Name = "House" },
                        new { Id = 23, Name = "Trance" },
                        new { Id = 24, Name = "DownTempo" },
                        new { Id = 25, Name = "Utility" },
                        new { Id = 26, Name = "Folk" },
                        new { Id = 27, Name = "Classical" },
                        new { Id = 28, Name = "World" }
                    );
                });

            modelBuilder.Entity("TheMediaProject.Domain.Music.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId");

                    b.Property<int>("Disc");

                    b.Property<TimeSpan>("Length");

                    b.Property<string>("Title");

                    b.Property<int>("Track");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Music.SongArtist", b =>
                {
                    b.Property<int>("ArtistId");

                    b.Property<int>("SongId");

                    b.HasKey("ArtistId", "SongId");

                    b.ToTable("SongArtists");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Podcasts.Podcast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FormatId");

                    b.Property<int?>("GenreId");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("FormatId");

                    b.HasIndex("GenreId");

                    b.ToTable("Podcasts");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Podcasts.PodcastFormat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PodcastFormats");

                    b.HasData(
                        new { Id = 1, Name = "Conversational" },
                        new { Id = 2, Name = "Interview" },
                        new { Id = 3, Name = "Storytelling" },
                        new { Id = 4, Name = "Educational" }
                    );
                });

            modelBuilder.Entity("TheMediaProject.Domain.Podcasts.PodcastGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PodcastGenres");

                    b.HasData(
                        new { Id = 1, Name = "History" },
                        new { Id = 2, Name = "Educational" },
                        new { Id = 3, Name = "Religious" },
                        new { Id = 4, Name = "Audio Drama" },
                        new { Id = 5, Name = "Sport" },
                        new { Id = 6, Name = "Comdey" },
                        new { Id = 7, Name = "Society and Culture" },
                        new { Id = 8, Name = "Feminist" },
                        new { Id = 9, Name = "Health" },
                        new { Id = 10, Name = "Business" },
                        new { Id = 11, Name = "News" },
                        new { Id = 12, Name = "Politics" },
                        new { Id = 13, Name = "Environment" },
                        new { Id = 14, Name = "Technology" },
                        new { Id = 15, Name = "Law" },
                        new { Id = 16, Name = "Philosophy" },
                        new { Id = 17, Name = "Games" },
                        new { Id = 18, Name = "Hobbies" }
                    );
                });

            modelBuilder.Entity("TheMediaProject.Domain.Podcasts.PodcastPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("PodcastId");

                    b.HasKey("Id");

                    b.HasIndex("PodcastId");

                    b.ToTable("PodcastPeople");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Podcasts.PodcastPersonPodcast", b =>
                {
                    b.Property<int>("PodcastId");

                    b.Property<int>("PodcastPersonId");

                    b.Property<int>("PersonRole");

                    b.HasKey("PodcastId", "PodcastPersonId");

                    b.ToTable("PodcastHosts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.Serie.Episode", b =>
                {
                    b.HasOne("TheMediaProject.Domain.Movies.Serie.Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheMediaProject.Domain.Movies.Serie.Season", b =>
                {
                    b.HasOne("TheMediaProject.Domain.Movies.Serie.Series")
                        .WithMany("Seasons")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheMediaProject.Domain.Music.Album", b =>
                {
                    b.HasOne("TheMediaProject.Domain.Music.Artist", "AlbumArtist")
                        .WithMany()
                        .HasForeignKey("AlbumArtistId");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Music.Artist", b =>
                {
                    b.HasOne("TheMediaProject.Domain.Music.Song")
                        .WithMany("Artists")
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Music.Song", b =>
                {
                    b.HasOne("TheMediaProject.Domain.Music.Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Podcasts.Podcast", b =>
                {
                    b.HasOne("TheMediaProject.Domain.Podcasts.PodcastFormat", "Format")
                        .WithMany()
                        .HasForeignKey("FormatId");

                    b.HasOne("TheMediaProject.Domain.Podcasts.PodcastGenre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");
                });

            modelBuilder.Entity("TheMediaProject.Domain.Podcasts.PodcastPerson", b =>
                {
                    b.HasOne("TheMediaProject.Domain.Podcasts.Podcast")
                        .WithMany("PodcastPeople")
                        .HasForeignKey("PodcastId");
                });
#pragma warning restore 612, 618
        }
    }
}
