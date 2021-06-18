using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class AddsUserIdentityToAppliances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Appliance",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appliance_UserId",
                table: "Appliance",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_AspNetUsers_UserId",
                table: "Appliance",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_AspNetUsers_UserId",
                table: "Appliance");

            migrationBuilder.DropIndex(
                name: "IX_Appliance_UserId",
                table: "Appliance");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appliance");
        }
    }
}
