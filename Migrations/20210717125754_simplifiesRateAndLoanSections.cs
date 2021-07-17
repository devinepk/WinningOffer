using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class simplifiesRateAndLoanSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conventional",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "FHA",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "Fixed_Rate",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "VA",
                table: "Financial");

            migrationBuilder.AddColumn<string>(
                name: "LoanType",
                table: "Financial",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rate_Type",
                table: "Financial",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanType",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "Rate_Type",
                table: "Financial");

            migrationBuilder.AddColumn<bool>(
                name: "Conventional",
                table: "Financial",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FHA",
                table: "Financial",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Fixed_Rate",
                table: "Financial",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VA",
                table: "Financial",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
