using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using TheMediaProject.Domain.Movies;
using TheMediaProject.Domain.Movies.Serie;
using TheMediaProject.Domain.Music;
using TheMediaProject.Domain.Podcasts;

namespace TheMediaProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieGenreMovie> MovieGenreMovies { get; set; }
        public DbSet<MovieCrewMember> MovieCrewMember { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<MovieGenreSeries> MovieGenreSeries { get; set; }
        public DbSet<SeriesCrewMember> SeriesCrewMembers { get; set; }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<MusicGenre> MusicGenres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }

        public DbSet<PodcastFormat> PodcastFormats { get; set; }
        public DbSet<PodcastGenre> PodcastGenres { get; set; }
        public DbSet<PodcastPerson> PodcastPeople { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<PodcastPersonPodcast> PodcastHosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieCrewMember>().HasKey(k => new { k.CrewMemberId, k.MovieId });
            builder.Entity<MovieGenreMovie>().HasKey(k => new { k.MovieGenreId, k.MovieId });
            builder.Entity<MovieGenreSeries>().HasKey(k => new { k.MovieGenreId, k.SerieId });
            builder.Entity<SongArtist>().HasKey(k => new { k.ArtistId, k.SongId });
            builder.Entity<PodcastPersonPodcast>().HasKey(k => new { k.PodcastId, k.PodcastPersonId });
            builder.Entity<SeriesCrewMember>().HasKey(k => new { k.CrewMemberId, k.MovieId });

            builder.Entity<MovieGenre>().HasData(
                new MovieGenre { Id = 1, Name = "Absurdist"},
                new MovieGenre { Id =2, Name="Action"},
                new MovieGenre { Id =3, Name = "Adventure" },
                new MovieGenre { Id =4, Name = "Comedy" },
                new MovieGenre { Id =5, Name = "Crime" },
                new MovieGenre { Id =6, Name = "Drama" },
                new MovieGenre { Id =7, Name = "Fantasy" },
                new MovieGenre { Id =8, Name = "Historical" },
                new MovieGenre { Id =9, Name = "Historical Fiction" },
                new MovieGenre { Id =10, Name = "Horror" },
                new MovieGenre { Id =11, Name = "Mystery" },
                new MovieGenre { Id =12, Name = "Romance" },
                new MovieGenre { Id =13, Name = "Satire" },
                new MovieGenre { Id =14, Name = "Science Fiction" },
                new MovieGenre { Id =15, Name = "Thriller" },
                new MovieGenre { Id =16, Name = "Western" }
                );

            builder.Entity<MusicGenre>().HasData(
                new MusicGenre { Id =1, Name = "Industrial" },
                new MusicGenre { Id =2, Name = "Metal" },
                new MusicGenre { Id =3, Name = "Hardcore Punk" },
                new MusicGenre { Id =4, Name = "Rock 'n' Roll" },
                new MusicGenre { Id =5, Name = "Classic Rock" },
                new MusicGenre { Id =6, Name = "Punk Rock" },
                new MusicGenre { Id =7, Name = "New Wave" },
                new MusicGenre { Id =8, Name = "Alternative Rock" },
                new MusicGenre { Id =9, Name = "Contemporary Rock" },
                new MusicGenre { Id =10, Name = "Pop" },
                new MusicGenre { Id =11, Name = "Country" },
                new MusicGenre { Id =12, Name = "Rhythm 'n' Blues" },
                new MusicGenre { Id =13, Name = "Blues" },
                new MusicGenre { Id =14, Name = "Gospel" },
                new MusicGenre { Id =15, Name = "Jazz" },
                new MusicGenre { Id =16, Name = "Reggae" },
                new MusicGenre { Id =17, Name = "Rap" },
                new MusicGenre { Id =18, Name = "Breakbeat" },
                new MusicGenre { Id =19, Name = "Drum 'n' Bass" },
                new MusicGenre { Id =20, Name = "Hardcore" },
                new MusicGenre { Id =21, Name = "Techno" },
                new MusicGenre { Id =22, Name = "House" },
                new MusicGenre { Id =23, Name = "Trance" },
                new MusicGenre { Id =24, Name = "DownTempo" },
                new MusicGenre { Id =25, Name = "Utility" },
                new MusicGenre { Id =26, Name = "Folk" },
                new MusicGenre { Id =27, Name = "Classical" },
                new MusicGenre { Id =28, Name = "World" }
                );

            builder.Entity<PodcastGenre>().HasData(
                new PodcastGenre { Id=1,Name="History"},
                new PodcastGenre { Id =2, Name = "Educational" },
                new PodcastGenre { Id =3, Name = "Religious" },
                new PodcastGenre { Id =4, Name = "Audio Drama" },
                new PodcastGenre { Id =5, Name = "Sport" },
                new PodcastGenre { Id =6, Name = "Comdey" },
                new PodcastGenre { Id =7, Name = "Society and Culture" },
                new PodcastGenre { Id =8, Name = "Feminist" },
                new PodcastGenre { Id =9, Name = "Health" },
                new PodcastGenre { Id =10, Name = "Business" },
                new PodcastGenre { Id =11, Name = "News" },
                new PodcastGenre { Id =12, Name = "Politics" },
                new PodcastGenre { Id =13, Name = "Environment" },
                new PodcastGenre { Id =14, Name = "Technology" },
                new PodcastGenre { Id =15, Name = "Law" },
                new PodcastGenre { Id =16, Name = "Philosophy" },
                new PodcastGenre { Id =17, Name = "Games" },
                new PodcastGenre { Id =18, Name = "Hobbies" }
                );

            builder.Entity<PodcastFormat>().HasData(
                new PodcastFormat { Id=1,Name="Conversational"},
                new PodcastFormat { Id =2, Name = "Interview" },
                new PodcastFormat { Id =3, Name = "Storytelling" },
                new PodcastFormat { Id =4, Name = "Educational" }
                );

            base.OnModelCreating(builder);
        }
    }
}
