using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class namingupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.RenameColumn(
                name: "AlbumArt",
                table: "Albums",
                newName: "Photo");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Podcasts",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieCrewMember",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    CrewMemberId = table.Column<int>(nullable: false),
                    MemberRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCrewMember", x => new { x.CrewMemberId, x.MovieId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCrewMember");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Podcasts");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Albums",
                newName: "AlbumArt");

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    CrewMemberId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    MemberRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.CrewMemberId, x.MovieId });
                });
        }
    }
}
