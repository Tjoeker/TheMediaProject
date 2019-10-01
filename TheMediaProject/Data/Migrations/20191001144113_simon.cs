using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class simon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieGenreSeries",
                columns: table => new
                {
                    MovieGenreId = table.Column<int>(nullable: false),
                    SerieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenreSeries", x => new { x.MovieGenreId, x.SerieId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenreSeries");
        }
    }
}
