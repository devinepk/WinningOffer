using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Data.Migrations
{
    public partial class createsonetomanyusertocontracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Contract");
        }
    }
}
