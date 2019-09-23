using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class crewmemberupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewMembers_Movies_MovieId1",
                table: "CrewMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CrewMembers_Series_SeriesId1",
                table: "CrewMembers");

            migrationBuilder.DropIndex(
                name: "IX_CrewMembers_MovieId1",
                table: "CrewMembers");

            migrationBuilder.DropIndex(
                name: "IX_CrewMembers_SeriesId1",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "SeriesId1",
                table: "CrewMembers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId1",
                table: "CrewMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesId1",
                table: "CrewMembers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_MovieId1",
                table: "CrewMembers",
                column: "MovieId1");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_SeriesId1",
                table: "CrewMembers",
                column: "SeriesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMembers_Movies_MovieId1",
                table: "CrewMembers",
                column: "MovieId1",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMembers_Series_SeriesId1",
                table: "CrewMembers",
                column: "SeriesId1",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
