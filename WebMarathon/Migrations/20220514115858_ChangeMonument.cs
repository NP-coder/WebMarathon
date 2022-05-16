using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMarathon.Migrations
{
    public partial class ChangeMonument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "WorldMonuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Town",
                table: "WorldMonuments");
        }
    }
}
