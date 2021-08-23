using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class ChangesUserIdSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_AspNetUsers_UserId",
                table: "Financial");

            migrationBuilder.DropIndex(
                name: "IX_Financial_UserId",
                table: "Financial");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Financial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Financial",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Financial");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Financial",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Financial_UserId",
                table: "Financial",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_AspNetUsers_UserId",
                table: "Financial",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
