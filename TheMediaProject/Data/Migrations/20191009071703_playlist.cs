using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class playlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_SeriesId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SeriesId",
                table: "Seasons");

            migrationBuilder.CreateTable(
                name: "PlaylistItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaylistId = table.Column<int>(nullable: false),
                    MediaId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: true),
                    PlaylistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.PlaylistId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistItems");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeriesId",
                table: "Seasons",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_SeriesId",
                table: "Seasons",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
