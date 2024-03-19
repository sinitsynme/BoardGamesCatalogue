using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGamesCatalogue.Migrations
{
    /// <inheritdoc />
    public partial class Addcolumnstoshopaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ShopAddress",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ShopAddress",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ShopAddress");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ShopAddress");
        }
    }
}
