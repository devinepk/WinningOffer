using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class dbupdates1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Property",
                newName: "ListingCompany");

            migrationBuilder.RenameColumn(
                name: "Agent",
                table: "Property",
                newName: "ListingAgentPhone");

            migrationBuilder.AddColumn<string>(
                name: "ListingAgent",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListingAgent",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "ListingCompany",
                table: "Property",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "ListingAgentPhone",
                table: "Property",
                newName: "Agent");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
