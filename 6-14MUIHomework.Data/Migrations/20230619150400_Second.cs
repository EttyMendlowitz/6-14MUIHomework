using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _6_14MUIHomework.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "SourceName",
                table: "Income");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Income",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceName",
                table: "Income",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
