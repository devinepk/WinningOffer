using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Data.Migrations
{
    public partial class simplifiesfuelpropanetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Propane_Leased",
                table: "FuelPropane");

            migrationBuilder.DropColumn(
                name: "Propane_NotApplicable",
                table: "FuelPropane");

            migrationBuilder.DropColumn(
                name: "Propane_NotRemain",
                table: "FuelPropane");

            migrationBuilder.RenameColumn(
                name: "Propane_Will_Remain",
                table: "FuelPropane",
                newName: "Propane_Tank_Status");

            migrationBuilder.RenameColumn(
                name: "Propane_Owned",
                table: "FuelPropane",
                newName: "Propane_Tank_Ownership");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Propane_Tank_Status",
                table: "FuelPropane",
                newName: "Propane_Will_Remain");

            migrationBuilder.RenameColumn(
                name: "Propane_Tank_Ownership",
                table: "FuelPropane",
                newName: "Propane_Owned");

            migrationBuilder.AddColumn<bool>(
                name: "Propane_Leased",
                table: "FuelPropane",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Propane_NotApplicable",
                table: "FuelPropane",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Propane_NotRemain",
                table: "FuelPropane",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
