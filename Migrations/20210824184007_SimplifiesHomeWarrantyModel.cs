using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class SimplifiesHomeWarrantyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer_To_Purchase_HW_Later",
                table: "HomeWarranty");

            migrationBuilder.DropColumn(
                name: "Buyer_Waves_Right_To_HW",
                table: "HomeWarranty");

            migrationBuilder.DropColumn(
                name: "New_Construction_HW",
                table: "HomeWarranty");

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Final_Options",
                table: "HomeWarranty",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer_Final_Options",
                table: "HomeWarranty");

            migrationBuilder.AddColumn<bool>(
                name: "Buyer_To_Purchase_HW_Later",
                table: "HomeWarranty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Buyer_Waves_Right_To_HW",
                table: "HomeWarranty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "New_Construction_HW",
                table: "HomeWarranty",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
