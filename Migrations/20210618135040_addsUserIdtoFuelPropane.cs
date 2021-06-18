using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class addsUserIdtoFuelPropane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FuelPropane",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuelPropane_UserId",
                table: "FuelPropane",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FuelPropane_AspNetUsers_UserId",
                table: "FuelPropane",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelPropane_AspNetUsers_UserId",
                table: "FuelPropane");

            migrationBuilder.DropIndex(
                name: "IX_FuelPropane_UserId",
                table: "FuelPropane");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FuelPropane");
        }
    }
}
