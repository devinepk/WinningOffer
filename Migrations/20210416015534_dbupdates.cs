using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class dbupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumBathroom",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "NumBedroom",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "subLotNum",
                table: "Property",
                newName: "SubLotNum");

            migrationBuilder.RenameColumn(
                name: "lotNum",
                table: "Property",
                newName: "LotNum");

            migrationBuilder.RenameColumn(
                name: "county",
                table: "Property",
                newName: "County");

            migrationBuilder.RenameColumn(
                name: "blockNum",
                table: "Property",
                newName: "BlockNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubLotNum",
                table: "Property",
                newName: "subLotNum");

            migrationBuilder.RenameColumn(
                name: "LotNum",
                table: "Property",
                newName: "lotNum");

            migrationBuilder.RenameColumn(
                name: "County",
                table: "Property",
                newName: "county");

            migrationBuilder.RenameColumn(
                name: "BlockNum",
                table: "Property",
                newName: "blockNum");

            migrationBuilder.AddColumn<int>(
                name: "NumBathroom",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumBedroom",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
