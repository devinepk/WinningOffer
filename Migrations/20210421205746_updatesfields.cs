using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class updatesfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Leaded",
                table: "Propane",
                newName: "Leased");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Leased",
                table: "Propane",
                newName: "Leaded");
        }
    }
}
