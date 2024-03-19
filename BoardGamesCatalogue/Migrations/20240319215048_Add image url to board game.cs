using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesCatalogue.Migrations
{
    /// <inheritdoc />
    public partial class Addimageurltoboardgame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BoardGames",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BoardGames");
        }
    }
}
