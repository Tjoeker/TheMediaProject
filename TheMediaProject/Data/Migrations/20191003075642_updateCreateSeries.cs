using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class updateCreateSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "SeriesCrewMembers",
                newName: "SeriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "SeriesCrewMembers",
                newName: "MovieId");
        }
    }
}
