using Microsoft.EntityFrameworkCore.Migrations;

namespace HellowWorld.Migrations
{
    public partial class UserCharecterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "charecters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_charecters_UsersId",
                table: "charecters",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_charecters_Users_UsersId",
                table: "charecters",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_charecters_Users_UsersId",
                table: "charecters");

            migrationBuilder.DropIndex(
                name: "IX_charecters_UsersId",
                table: "charecters");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "charecters");
        }
    }
}
