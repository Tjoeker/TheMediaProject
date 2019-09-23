using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class updatenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesActors",
                table: "SeriesActors");

            migrationBuilder.RenameTable(
                name: "SeriesActors",
                newName: "SeriesCrewMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesCrewMembers",
                table: "SeriesCrewMembers",
                columns: new[] { "CrewMemberId", "MovieId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesCrewMembers",
                table: "SeriesCrewMembers");

            migrationBuilder.RenameTable(
                name: "SeriesCrewMembers",
                newName: "SeriesActors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesActors",
                table: "SeriesActors",
                columns: new[] { "CrewMemberId", "MovieId" });
        }
    }
}
