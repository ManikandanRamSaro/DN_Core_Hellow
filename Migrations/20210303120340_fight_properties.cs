using Microsoft.EntityFrameworkCore.Migrations;

namespace HellowWorld.Migrations
{
    public partial class fight_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defeats",
                table: "charecters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fights",
                table: "charecters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vectories",
                table: "charecters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defeats",
                table: "charecters");

            migrationBuilder.DropColumn(
                name: "Fights",
                table: "charecters");

            migrationBuilder.DropColumn(
                name: "Vectories",
                table: "charecters");
        }
    }
}
