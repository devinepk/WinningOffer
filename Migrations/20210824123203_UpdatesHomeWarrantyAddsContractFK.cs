using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class UpdatesHomeWarrantyAddsContractFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer_To_Pay_HW",
                table: "HomeWarranty");

            migrationBuilder.DropColumn(
                name: "HW",
                table: "HomeWarranty");

            migrationBuilder.DropColumn(
                name: "Seller_To_Pay_HW",
                table: "HomeWarranty");

            migrationBuilder.RenameColumn(
                name: "HW_Price",
                table: "HomeWarranty",
                newName: "Price");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "HomeWarranty",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Who_Pays",
                table: "HomeWarranty",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeWarranty_ContractId",
                table: "HomeWarranty",
                column: "ContractId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWarranty_Contract_ContractId",
                table: "HomeWarranty",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeWarranty_Contract_ContractId",
                table: "HomeWarranty");

            migrationBuilder.DropIndex(
                name: "IX_HomeWarranty_ContractId",
                table: "HomeWarranty");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "HomeWarranty");

            migrationBuilder.DropColumn(
                name: "Who_Pays",
                table: "HomeWarranty");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "HomeWarranty",
                newName: "HW_Price");

            migrationBuilder.AddColumn<bool>(
                name: "Buyer_To_Pay_HW",
                table: "HomeWarranty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HW",
                table: "HomeWarranty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Seller_To_Pay_HW",
                table: "HomeWarranty",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
