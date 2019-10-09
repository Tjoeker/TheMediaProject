using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMediaProject.Data.Migrations
{
    public partial class playlistitemupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PlaylistItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "PlaylistItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "PlaylistItems");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PlaylistItems",
                nullable: false,
                defaultValue: 0);
        }
    }
}
