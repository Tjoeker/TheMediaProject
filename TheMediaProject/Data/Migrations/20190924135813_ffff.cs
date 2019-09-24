using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class ffff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewMembers_Movies_MovieId",
                table: "CrewMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CrewMembers_Series_SeriesId",
                table: "CrewMembers");

            migrationBuilder.DropIndex(
                name: "IX_CrewMembers_MovieId",
                table: "CrewMembers");

            migrationBuilder.DropIndex(
                name: "IX_CrewMembers_SeriesId",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "CrewMembers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "CrewMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "CrewMembers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_MovieId",
                table: "CrewMembers",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_SeriesId",
                table: "CrewMembers",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMembers_Movies_MovieId",
                table: "CrewMembers",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMembers_Series_SeriesId",
                table: "CrewMembers",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
