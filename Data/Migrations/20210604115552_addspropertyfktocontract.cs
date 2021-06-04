using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Data.Migrations
{
    public partial class addspropertyfktocontract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyID",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyID",
                table: "Contract");
        }
    }
}
