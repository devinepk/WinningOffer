using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class RemovesUnnecessaryFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sourceURLs",
                table: "Property",
                newName: "SourceURLs");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Property",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "Property",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Property",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "numBedroom",
                table: "Property",
                newName: "NumBedroom");

            migrationBuilder.RenameColumn(
                name: "numBathroom",
                table: "Property",
                newName: "NumBathroom");

            migrationBuilder.RenameColumn(
                name: "mlsNumber",
                table: "Property",
                newName: "MlsNumber");

            migrationBuilder.RenameColumn(
                name: "imageURLs",
                table: "Property",
                newName: "ImageURLs");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Property",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "company",
                table: "Property",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Property",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "agent",
                table: "Property",
                newName: "Agent");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Property",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "geoLocation",
                table: "Property",
                newName: "subLotNum");

            migrationBuilder.RenameColumn(
                name: "dateUpdated",
                table: "Property",
                newName: "lotNum");

            migrationBuilder.RenameColumn(
                name: "dateAdded",
                table: "Property",
                newName: "county");

            migrationBuilder.AddColumn<string>(
                name: "DeedBook",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Page",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "blockNum",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeedBook",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "blockNum",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "SourceURLs",
                table: "Property",
                newName: "sourceURLs");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Property",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Property",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Property",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "NumBedroom",
                table: "Property",
                newName: "numBedroom");

            migrationBuilder.RenameColumn(
                name: "NumBathroom",
                table: "Property",
                newName: "numBathroom");

            migrationBuilder.RenameColumn(
                name: "MlsNumber",
                table: "Property",
                newName: "mlsNumber");

            migrationBuilder.RenameColumn(
                name: "ImageURLs",
                table: "Property",
                newName: "imageURLs");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Property",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Property",
                newName: "company");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Property",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Agent",
                table: "Property",
                newName: "agent");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Property",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "subLotNum",
                table: "Property",
                newName: "geoLocation");

            migrationBuilder.RenameColumn(
                name: "lotNum",
                table: "Property",
                newName: "dateUpdated");

            migrationBuilder.RenameColumn(
                name: "county",
                table: "Property",
                newName: "dateAdded");
        }
    }
}
