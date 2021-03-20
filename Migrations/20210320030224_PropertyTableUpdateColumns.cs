using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class PropertyTableUpdateColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "agent",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "company",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dateAdded",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dateUpdated",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "geoLocation",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageURLs",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mlsNumber",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numBathroom",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numBedroom",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "phones",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "postalCode",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sourceURLs",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "agent",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "city",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "company",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "country",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "dateAdded",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "dateUpdated",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "geoLocation",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "imageURLs",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "mlsNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "numBathroom",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "numBedroom",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "phones",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "postalCode",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "sourceURLs",
                table: "Property");
        }
    }
}
