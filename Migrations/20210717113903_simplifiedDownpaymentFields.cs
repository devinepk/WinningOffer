using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class simplifiedDownpaymentFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cash",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "Gift",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "LineOfEquity",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "Other_Financing",
                table: "Financial");

            migrationBuilder.AddColumn<string>(
                name: "DownPaymentAmount",
                table: "Financial",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DownPaymentSource",
                table: "Financial",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownPaymentAmount",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "DownPaymentSource",
                table: "Financial");

            migrationBuilder.AddColumn<bool>(
                name: "Cash",
                table: "Financial",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gift",
                table: "Financial",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LineOfEquity",
                table: "Financial",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Other_Financing",
                table: "Financial",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
