using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    CrewMemberId = table.Column<int>(nullable: false),
                    MemberRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.CrewMemberId, x.MovieId });
                });

            migrationBuilder.CreateTable(
                name: "MovieGenreMovies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    MovieGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenreMovies", x => new { x.MovieGenreId, x.MovieId });
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PlayTime = table.Column<TimeSpan>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastFormats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastHosts",
                columns: table => new
                {
                    PodcastId = table.Column<int>(nullable: false),
                    PodcastPersonId = table.Column<int>(nullable: false),
                    PersonRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastHosts", x => new { x.PodcastId, x.PodcastPersonId });
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriesActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    CrewMemberId = table.Column<int>(nullable: false),
                    MemberRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesActors", x => new { x.CrewMemberId, x.MovieId });
                });

            migrationBuilder.CreateTable(
                name: "SongArtists",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongArtists", x => new { x.ArtistId, x.SongId });
                });

            migrationBuilder.CreateTable(
                name: "Podcasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: true),
                    FormatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Podcasts_PodcastFormats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "PodcastFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Podcasts_PodcastGenres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "PodcastGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: true),
                    MovieId1 = table.Column<int>(nullable: true),
                    SeriesId = table.Column<int>(nullable: true),
                    SeriesId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewMembers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrewMembers_Movies_MovieId1",
                        column: x => x.MovieId1,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrewMembers_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrewMembers_Series_SeriesId1",
                        column: x => x.SeriesId1,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeasonNumber = table.Column<int>(nullable: false),
                    SeriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastPeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PodcastId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastPeople_Podcasts_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PlayTime = table.Column<TimeSpan>(nullable: false),
                    SeasonId = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Track = table.Column<int>(nullable: false),
                    Disc = table.Column<int>(nullable: false),
                    Length = table.Column<TimeSpan>(nullable: false),
                    AlbumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SongId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    AlbumArtistId = table.Column<int>(nullable: true),
                    AlbumArt = table.Column<byte[]>(nullable: true),
                    GenreId = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_AlbumArtistId",
                        column: x => x.AlbumArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Absurdist" },
                    { 16, "Western" },
                    { 14, "Science Fiction" },
                    { 13, "Satire" },
                    { 12, "Romance" },
                    { 11, "Mystery" },
                    { 10, "Horror" },
                    { 9, "Historical Fiction" },
                    { 15, "Thriller" },
                    { 7, "Fantasy" },
                    { 6, "Drama" },
                    { 5, "Crime" },
                    { 4, "Comedy" },
                    { 3, "Adventure" },
                    { 2, "Action" },
                    { 8, "Historical" }
                });

            migrationBuilder.InsertData(
                table: "MusicGenres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 18, "Breakbeat" },
                    { 19, "Drum 'n' Bass" },
                    { 20, "Hardcore" },
                    { 21, "Techno" },
                    { 22, "House" },
                    { 26, "Folk" },
                    { 24, "DownTempo" },
                    { 25, "Utility" },
                    { 27, "Classical" },
                    { 28, "World" },
                    { 16, "Reggae" },
                    { 23, "Trance" },
                    { 15, "Jazz" },
                    { 17, "Rap" },
                    { 13, "Blues" },
                    { 12, "Rhythm 'n' Blues" },
                    { 14, "Gospel" },
                    { 11, "Country" },
                    { 10, "Pop" },
                    { 9, "Contemporary Rock" },
                    { 8, "Alternative Rock" },
                    { 7, "New Wave" },
                    { 6, "Punk Rock" },
                    { 5, "Classic Rock" },
                    { 4, "Rock 'n' Roll" },
                    { 3, "Hardcore Punk" },
                    { 2, "Metal" },
                    { 1, "Industrial" }
                });

            migrationBuilder.InsertData(
                table: "PodcastFormats",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Storytelling" },
                    { 4, "Educational" },
                    { 1, "Conversational" },
                    { 2, "Interview" }
                });

            migrationBuilder.InsertData(
                table: "PodcastGenres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 16, "Philosophy" },
                    { 15, "Law" },
                    { 14, "Technology" },
                    { 13, "Environment" },
                    { 12, "Politics" },
                    { 11, "News" },
                    { 10, "Business" },
                    { 9, "Health" },
                    { 8, "Feminist" },
                    { 6, "Comdey" },
                    { 5, "Sport" },
                    { 4, "Audio Drama" },
                    { 3, "Religious" },
                    { 2, "Educational" },
                    { 1, "History" },
                    { 17, "Games" },
                    { 7, "Society and Culture" },
                    { 18, "Hobbies" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_AlbumArtistId",
                table: "Albums",
                column: "AlbumArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_SongId",
                table: "Artists",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_MovieId",
                table: "CrewMembers",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_MovieId1",
                table: "CrewMembers",
                column: "MovieId1");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_SeriesId",
                table: "CrewMembers",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_SeriesId1",
                table: "CrewMembers",
                column: "SeriesId1");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastPeople_PodcastId",
                table: "PodcastPeople",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_FormatId",
                table: "Podcasts",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_GenreId",
                table: "Podcasts",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeriesId",
                table: "Seasons",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_AlbumArtistId",
                table: "Albums");

            migrationBuilder.DropTable(
                name: "CrewMembers");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieGenreMovies");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MusicGenres");

            migrationBuilder.DropTable(
                name: "PodcastHosts");

            migrationBuilder.DropTable(
                name: "PodcastPeople");

            migrationBuilder.DropTable(
                name: "SeriesActors");

            migrationBuilder.DropTable(
                name: "SongArtists");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Podcasts");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "PodcastFormats");

            migrationBuilder.DropTable(
                name: "PodcastGenres");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
